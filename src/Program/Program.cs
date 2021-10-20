using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;


namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //cre una carpeta llamada "filtradas" dentro de program para guardar las fotos que voy aciendo//
            PictureProvider provider= new PictureProvider();
            IPicture picture= provider.GetPicture("luke.jpg");
            PipeNull pipeNull=new PipeNull();
            FilterNegative filterNegative= new FilterNegative();
            PipeSerial pipeSerial02=new PipeSerial(filterNegative,pipeNull);
            FilterGreyscale filterGreyscale=new FilterGreyscale();
            PipeSerial pipeSerial01=new PipeSerial(filterGreyscale,pipeSerial02);
            IPicture pic=pipeSerial01.Send(picture); //Tengo que convertir la funcion de pipeserial.send en su propia instancia de Ipicture, esa instancia conserv a los cambios//
            provider.SavePicture(pic,"filtradas/luke02.jpg"); //esto guarda la seginda instancia de IPicture (con los filtros aplicados) en la direccion desada//  */
            

            PictureProvider provider= new PictureProvider();
            IPicture picture= provider.GetPicture("beer.jpg");
            FilterNegative filterNegative= new FilterNegative();
            FilterGreyscale filterGreyscale=new FilterGreyscale();
            FilterPersist filterPersist01=new FilterPersist(); //fileterPersist es un tipo de filtro que cre para que mande la foto como le llega a un direccion de guardado, no altera la foto de ninfuna manera//
            filterPersist01.Address("filtradas/beer01.jpg");   //esto se usa para seleccionar la dirrecion y nombre de la foto que le llega a fileterPersist//
            FilterPersist filterPersist02=new FilterPersist();
            filterPersist02.Address("filtradas/beer02.jpg");
            PipeNull pipeNull=new PipeNull();
            PipeSerial pipeSerial04=new PipeSerial(filterPersist01,pipeNull);
            PipeSerial pipeSerial03=new PipeSerial(filterNegative,pipeSerial04);
            PipeSerial pipeSerial02=new PipeSerial(filterPersist02,pipeSerial03);
            PipeSerial pipeSerial01=new PipeSerial(filterGreyscale,pipeSerial02);
            pipeSerial01.Send(picture);




           

             
        }
    }
}
