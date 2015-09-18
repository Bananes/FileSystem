using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class File
    {
        public string Nom { get; set; }
        public Directory parent { get; set; }
        public string path { get; set; }
        public int permission;

        public File(string Nom, Directory parent)
        {
            this.Nom = Nom;
            parent.Fichiers.Add(this);
            this.parent = parent;
            string pathEntier = parent.path + "/" + Nom;
            path = pathEntier;
            permission = 4;
        }

        public bool mkdir(string name)
        {
            bool create = false;
            if (this.canWrite())
            {
                Directory dos = new Directory(name, (Directory)this);
                return create = true;
            }
            else
            {
                Console.WriteLine("Permissions insufissantes : ");
                return create;
            }
        }

        public bool isFile()
        {
            if (this.GetType().ToString() == "FileSystem.File")
            {
                return true;
            }
            return false;
        }


        public bool isDirectory()
        {
            if (this.GetType().ToString() == "FileSystem.Directory")
            {
                return true;
            }
            return false;
        }
        public File(string Nom)
        {
            this.Nom = Nom;
        }

        public string getPath()
        {
            return this.path;
        }

        public string getName()
        {
            return this.Nom;
        }

        public File getParent()
        {
            if (parent == null)
            {
                Console.WriteLine("Impossible de remonter plus haut...");
                return this;
            }
            else
            {
                return this.parent;
            }
        }

        public File getRoot()
        { 
            return this.getParent();
        }

        public bool canWrite()
        {
            return (permission & 2) > 0;
        }
        public bool canExecute()
        {
            return (permission & 1) > 0;
        }
        public bool canRead()
        {
            return (permission & 4) > 0;
        }

        public void chmod(int permission)
        {
            this.permission = permission;
        }
    }
}
