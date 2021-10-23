using System;
using System.IO;
using System.Drawing;
using CompAndDel;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using TwitterUCU;




namespace CompAndDel.Filters
{
    public class FilterTwitterImage: IFilter
    {
        public IPicture Filter(IPicture image)
        
        {
            IPicture result = image.Clone();
            PictureProvider Provider_Twitter=new PictureProvider();
            TwitterImage twitter_image = new TwitterImage();
            Provider_Twitter.SavePicture(result,pic_addres);
            System.Console.WriteLine(twitter_image.PublishToTwitter(message,pic_addres));
            File.Delete(pic_addres);
            return image;
        }
        private string message;
        public void Message(string message)
        {
            this.message=message;
        }

        private string pic_addres;

        public void Pic_addres(string addres_location)
        {
            pic_addres=addres_location;
        }
        

            
        

        

    }






}
