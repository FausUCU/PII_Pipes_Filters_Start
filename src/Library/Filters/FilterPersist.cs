using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public class FilterPersist: IFilter
    {
        public IPicture Filter(IPicture image)
        {
            IPicture result = image.Clone();
            PictureProvider provider_Persist= new PictureProvider();
            provider_Persist.SavePicture(result,this.address);
            return result;
        }

        private string address;
        public void Address(string dir)
        {
            this.address=dir;
        }
        
    }
    
}
