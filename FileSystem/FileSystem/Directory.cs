using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Directory : File
    {
        public List<File> Fichiers = new List<File>();

        public Directory(string Nom, Directory parent)
            : base(Nom, parent)
        { }

        public Directory(string Nom)
            : base(Nom)
        {
            this.Nom = Nom;
            path = Nom;
        }

        public bool createNewFile(string name)
        {
            bool create = false;
            if (this.canWrite())
            {
                File fichier = new File(name, (Directory)this);
                return create = true;
            }
            else
            {
                Console.WriteLine("Permissions insufissantes :{");
                return create;
            }
        }
        public List<File> ls()
        {
            return this.Fichiers;
        }

        public bool renameTo(string newName)
        {
            bool change = false;
            if (this.canWrite())
            {
                return change = true;
            }
            else
            {
                Console.WriteLine("Permissions insufissantes :{");
                return change;
            }
        }

        public File cd(string name)
        {
            foreach (File file in this.Fichiers)
            {
                if(name == file.Nom)
                {
                    if (file.GetType().ToString() == "FileSystem.Directory")
                    {
                        return (Directory)file;
                    }
                    else
                    {
                        return file;
                    }
                }
            }
            return this;
        }

        public bool delete(string name)
        {
            bool create = false, test = false;
            if (this.canWrite())
            {
                foreach (File fichier in Fichiers)
                {
                    if (name == fichier.Nom)
                    {
                        Fichiers.Remove(fichier);
                        test = true;
                    }
                }
            if (test == false)
            {
                Console.WriteLine("Fichier inexistant...");
            }
            return create = true;
            }
            else
            {
                return create;
            }
            
        }
    }
}