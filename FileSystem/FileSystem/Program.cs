using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Oui je sais c'est pas C: mais j'm'embrouille moins comme ça
            File C = new Directory("C:");
            Directory Actuel = (Directory)C;
            commande(Actuel);
            
            
        }
        public static void commande(Directory Actuel)
        {
        Console.Write(Actuel.path + "> ");
        string commandes = Console.ReadLine();
        List<string> action = new List<string> (commandes.Split(' '));
               switch (action[0])
               {
                   case "path":
                       if (action.Count == 1)
                       {
                           Console.WriteLine(Actuel.getPath());
                       }
                       else
                       {
                           goto default;
                       }
                   break;
                   case "create":
                   if (action.Count == 2)
                   {
                       bool test = false;
                       foreach (File fichier in Actuel.Fichiers)
                       {
                           if (fichier.Nom == action[1])
                           {
                               Console.WriteLine("Ce fichier existe déjà");
                               test = true;
                               break;
                           }
                       }
                       if (test == false)
                       {
                           Actuel.createNewFile(action[1]);
                       }
                   }
                   else
                   {
                       goto default;
                   }  
                   break;
                   case "mkdir":
                   if (action.Count == 2)
                   {
                       bool test = false;
                       foreach (File fichier in Actuel.Fichiers)
                       {
                           if (fichier.Nom == action[1])
                           {
                               Console.WriteLine("Ce fichier existe déjà");
                               test = true;
                               break;
                           }
                       }
                       if (test == false)
                       {
                           Actuel.mkdir(action[1]);
                       }
                   }
                   else
                   {
                       goto default;
                   }  
                   break;
                   case "name":
                   if (action.Count == 1)
                   {
                       Console.WriteLine(Actuel.getName());
                   }
                   else
                   {
                       goto default;
                   }
                   break;
                   case "ls":
                   if (action.Count == 1)
                   {
                       if (Actuel.Fichiers.Count > 0)
                       {
                           Console.WriteLine();
                           foreach (File file in Actuel.ls())
                           {

                               if (file.GetType().ToString() == "FileSystem.Directory")
                               {
                                   Console.WriteLine("D " + file.Nom);
                               }
                               else
                               {
                                   Console.WriteLine("F " + file.Nom);
                               }
                           }
                           Console.WriteLine();
                       }
                   }
                   else
                   {
                       goto default;
                   }
                   break;
                   case "cd":
                       if (action.Count == 2)
                       {
                           if (Actuel.cd(action[1]).Nom == Actuel.Nom)
                           {
                               Console.WriteLine("Répertoire inexistant...");
                           }
                           else
                           {
                               if (Actuel.cd(action[1]).GetType().ToString() == "FileSystem.File")
                               {
                                   Console.WriteLine("Vous ne pouvez pas entrer dans un fichier");
                               }
                               else
                               {
                                   Actuel = (Directory)Actuel.cd(action[1]);
                               }
                           }
                       }
                       else
                       {
                           goto default;
                       }
                   break;
                   case "file":
                       if (action.Count == 1)
                       {
                           if (Actuel.isFile() == true)
                           {
                               Console.WriteLine("C'est un fichier");
                           }
                           else
                           {
                               Console.WriteLine("Ce n'est pas un fichier");
                           }
                       }
                       else
                       {
                           goto default;
                       }
                        
                   break;
                   case "rename":
                   if (action.Count == 3)
                   {
                       if (Actuel.renameTo(action[2]) == true)
                       {
                           bool work = false;
                           foreach (File fichier in Actuel.Fichiers)
                           {
                               if (action[2] == fichier.Nom)
                               {
                                   Console.WriteLine("Ce nom est déjà existant...");
                                   work = true;
                                   break;
                               }
                               else
                               {
                                   if (fichier.Nom == action[1])
                                   {
                                       work = true;
                                       fichier.Nom = action[2];
                                       break;
                                   }
                               }
                           }
                           if (work == false)
                           {
                               Console.WriteLine("Impossible de renommer, fichier inexistant");
                           }
                       }
                   }
                   else
                   {
                       goto default;
                   }                  
                   break;
                   case "chmod":
                       if (action.Count == 2)
                       {
                           int permission;
                       if (Int32.TryParse(action[1], out permission))
                       {
                           permission = Int32.Parse(action[1]);
                           Actuel.chmod(permission);
                       }
                       else
                       {
                           Console.WriteLine("Permission impossible");
                       }
                       }
                       else
                       {
                           goto default;
                       }
                       
                   break;
                   case "directory":
                   if (action.Count == 1)
                   {
                       if (Actuel.isDirectory() == true)
                       {
                           Console.WriteLine("C'est un répertoire");
                       }
                       else
                       {
                           Console.WriteLine("Ce n'est pas un répertoire");
                       }
                   }
                   else
                   {
                       goto default;
                   }
                   break;
                   case "delete":
                   if (action.Count == 2)
                   {
                       Actuel.delete(action[1]);
                   }
                   else
                   {
                       goto default;
                   }
                        
                   break;
                   case "root":
                   if (action.Count == 1)
                   {
                       Directory root = Actuel;
                       while (root.parent.Nom != "C:")
                       {
                           root = (Directory)root.getParent();
                       }
                       Console.WriteLine(root.Nom);
                   }
                   else
                   {
                       goto default;
                   }                   
                   break;
                   case "parent":
                   if (action.Count == 1)
                   {
                       if (Actuel.getParent() != Actuel)
                       {
                           Actuel = (Directory)Actuel.getParent();
                       }
                       
                   }
                   else
                   {
                       goto default;
                   }
                   break;
                   case "exit":
                   if (action.Count == 1)
                   {
                       System.Environment.Exit(-1);
                   }
                   else
                   {
                       goto default;
                   } 
                   break;
                   default:
                   Console.WriteLine("Commande inexistante, incomplète ou argument non valide");
                   break;
               }
               commande(Actuel);
            
        }

        public static void runOrNot(List<string> run, Directory Actuel)
        {
            if (run.Count != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Commande érroné ou incomplète");
                Console.ResetColor();
                commande(Actuel);
            }
        }
    }
}
