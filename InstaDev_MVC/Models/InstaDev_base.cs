using System.IO;

namespace InstaDev_MVC.Models
{
    public class InstaDev_base
    {
        
        public void CreateFolderAndFile(string path){

            string folder   = path.Split("/")[0];
            

            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(path)){
                File.Create(path).Close();
            }
        }



        


    }
}