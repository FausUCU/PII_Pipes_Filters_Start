using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider= new PictureProvider();
            IPicture picture= provider.GetPicture("C:/Users/faust/OneDrive/Escritorio/Programacion02/Ejercisios/Imagenes/mrKrab.jpg");
            PipeNull pipeNull=new PipeNull();
            FilterNegative filterNegative= new FilterNegative();
            PipeSerial pipeSerial02=new PipeSerial(filterNegative,pipeNull);
            FilterGreyscale filterGreyscale=new FilterGreyscale();
            PipeSerial pipeSerial01=new PipeSerial(filterGreyscale,pipeSerial02);
            pipeSerial01.Send(picture);
            provider.SavePicture(picture,"C:/Users/faust/OneDrive/Escritorio/Programacion02/Ejercisios/Imagenes/save/filtro02.jpg");
        }
    }
}
