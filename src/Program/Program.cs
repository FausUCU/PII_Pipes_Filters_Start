using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using System.Threading.Tasks;


namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {

            PictureProvider provider= new PictureProvider();
            IPicture picture= provider.GetPicture("beer.jpg");
            FilterNegative filterNegative= new FilterNegative();
            FilterGreyscale filterGreyscale=new FilterGreyscale();
            FilterTwitterImage filterTwitterImage=new FilterTwitterImage();
            filterTwitterImage.Message("Prueba Twiter 02, FH");    //El texto con el que se publica la imagen en Twitter//
            filterTwitterImage.Pic_addres("filtradas/beer05.jpg"); //filterTwitterImage no puede mandar directamente la foto que le llega, primero la guarda en esta direccion, de hay la envia y imediatamente la borra por lo que no deveria quedar registro de la foto despues de enviarla//
            FilterPersist filterPersist=new FilterPersist();  //fileterPersist es un tipo de filtro que arme para que mande la foto como le llega a un direccion de guardado, no altera la foto de ninfuna manera//
            filterPersist.Address("filtradas/beer06.jpg");   //esto se usa para seleccionar la dirrecion y nombre de la foto que le llega a fileterPersist//
            PipeNull pipeNull=new PipeNull();
            PipeSerial pipeSerial04=new PipeSerial(filterTwitterImage,pipeNull);
            PipeSerial pipeSerial03=new PipeSerial(filterNegative,pipeSerial04);
            PipeSerial pipeSerial02=new PipeSerial(filterPersist,pipeSerial03);
            PipeSerial pipeSerial01=new PipeSerial(filterGreyscale,pipeSerial02);
            pipeSerial01.Send(picture); //Tengo que convertir la funcion de pipeserial.send en su propia instancia de Ipicture, esa instancia conserve a los cambios//
            
        }
    }
}
