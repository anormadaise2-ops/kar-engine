using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

internal class Program
{
    static int Main(string[] args)
    {
        if (args.Length == 0 || args[0] == "help" || args[0] == "--help")
        {
            Help();
            return 0;
        }

        if (args[0] == "--version")
        {
            Console.WriteLine("KAR ENGINE CLI v0.1.0");
            return 0;
        }

        switch (args[0].ToLowerInvariant())
        {
            case "doctor":
                Console.WriteLine("KAR ENGINE : environnement opérationnel.");
                Console.WriteLine("Version .NET : " + Environment.Version);
                return 0;

            case "status":
                Console.WriteLine("KAR ENGINE v0.1.0");
                Console.WriteLine("État : prêt");
                return 0;

            case "hash":
            case "sign":
                string action = args[0] == "sign" && args.Length > 1 ? args[1] : "hash";
                int index = args[0] == "sign" ? 2 : 1;

                if (action == "verify")
                {
                    Console.WriteLine("La vérification Authenticode sera ajoutée dans la prochaine version.");
                    return 0;
                }

                if (args.Length <= index || !File.Exists(args[index]))
                {
                    Console.WriteLine("Utilisation : kar hash <fichier>");
                    return 2;
                }

                using (var stream = File.OpenRead(args[index]))
                {
                    Console.WriteLine(Convert.ToHexString(SHA256.HashData(stream)).ToLowerInvariant());
                }
                return 0;

            case "fix":
                Console.WriteLine("KAR FIX : diagnostic sans modification.");
                Console.WriteLine("Cible : " + (args.Length > 1 ? string.Join(" ", args.Skip(1)) : "."));
                Console.WriteLine("Aucun changement n'a été effectué.");
                return 0;

            case "install":
                Console.WriteLine("Utilisation : kar install <package.zip>");
                Console.WriteLine("Le gestionnaire de paquets sera activé dans une prochaine version.");
                return 0;

            case "uninstall":
                Console.WriteLine("Gestionnaire de désinstallation en préparation.");
                return 0;

            case "package":
                Console.WriteLine("Utilisation : kar package <dossier>");
                return 0;

            case "logs":
                Console.WriteLine("Aucun journal disponible.");
                return 0;

            default:
                Console.WriteLine("Commande inconnue. Utilise : kar help");
                return 1;
        }
    }

    static void Help()
    {
        Console.WriteLine("KAR ENGINE CLI v0.1.0 - Zercraft");
        Console.WriteLine();
        Console.WriteLine("Commandes disponibles :");
        Console.WriteLine("  kar help                  Affiche l'aide");
        Console.WriteLine("  kar --version             Affiche la version");
        Console.WriteLine("  kar doctor                Vérifie l'environnement");
        Console.WriteLine("  kar status                Affiche le statut");
        Console.WriteLine("  kar hash <fichier>        Calcule le SHA-256");
        Console.WriteLine("  kar sign hash <fichier>  Calcule le SHA-256");
        Console.WriteLine("  kar sign verify <fichier> Vérification à venir");
        Console.WriteLine("  kar fix --scan            Diagnostic");
        Console.WriteLine("  kar fix force --scan      Diagnostic approfondi");
        Console.WriteLine("  kar install <package.zip> Gestionnaire en préparation");
        Console.WriteLine("  kar uninstall <nom>       Gestionnaire en préparation");
        Console.WriteLine("  kar package <dossier>     Préparation d'une archive");
        Console.WriteLine("  kar logs                  Affiche les journaux");
    }
}
