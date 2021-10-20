using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;


namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //cre una carpeta llamada "filtradas" dentro de program para guardar las fotos que voy aciendo//
            PictureProvider provider= new PictureProvider();
            IPicture picture= provider.GetPicture("luke.jpg");
            PipeNull pipeNull=new PipeNull();
            FilterNegative filterNegative= new FilterNegative();
            PipeSerial pipeSerial02=new PipeSerial(filterNegative,pipeNull);
            FilterGreyscale filterGreyscale=new FilterGreyscale();
            PipeSerial pipeSerial01=new PipeSerial(filterGreyscale,pipeSerial02);
            IPicture pic=pipeSerial01.Send(picture); //Tengo que convertir la funcion de pipeserial.send en su propia instancia de Ipicture, esa instancia conserv a los cambios//
            provider.SavePicture(pic,"filtradas/luke02.jpg"); //esto guarda la seginda instancia de IPicture (con los filtros aplicados) en la direccion desada//
            
            
           

             
        }
    }
}
