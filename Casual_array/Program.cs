using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Casual_array
{
    class Program
    {
        static void Main(string[] args)
        {
            //variabile per la selezione dell'operazione
            int selezione;
            //condizione booleana di uscita dal programma
            bool exit = false;
            //condizione per controllo numerico nell'indice della lista
            bool list_index = false;
            //variabile per il valore i-esimo della lista, utilizzata anche come controllo
            string valore_lista="";
            //indice della lista da restituire a partire dal fondo
            int n_ultimo=0;
            //lista generica
            List<object> lista_generica = new List<object>();
            //path del file da controllare
            string path_file;
            //parola da cercare
            string word;
            //ritorno valore esercizio 2
            int ret_es_2;
            do
            {
                Console.WriteLine("Selezionare la funzione desiderata");
                Console.WriteLine("1 per Esercizio 1");
                Console.WriteLine("2 per Esercizio 2");
                Console.WriteLine("3 per Esercizio 3");
                Console.WriteLine("0 per terminare");
                Console.WriteLine("");
                selezione = Convert.ToInt32(Console.ReadLine());
                switch (selezione)
                {
                    case 1:
                        Console.WriteLine("");
                        Console.WriteLine("Inserire il valore N della lunghezza del vettore");
                        Esercizio1(Convert.ToInt32(Console.ReadLine()));
                        Console.ReadLine();
                        Console.WriteLine("");
                        break;
                    case 3:
                        Console.WriteLine("");
                        Console.WriteLine("Programma per la ricerca di una parola all'interno di un file di testo");
                        Console.WriteLine("");
                        Console.WriteLine("Inserire il path completo del file da controllare");
                        Console.WriteLine("");
                        
                        path_file = Console.ReadLine();

                        Console.WriteLine("");
                        Console.WriteLine("Inserire la parola da cercare nel file selezionato");
                        Console.WriteLine("");
                        word = Console.ReadLine();
                        Console.WriteLine("");
                        Console.Write("Il numero delle parola all'interno del file è: ");
                        Console.WriteLine(Esercizio3(path_file,word));
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Programma per restituire l'n-esimo elemento di una lista generica");
                        Console.WriteLine("");
                        Console.WriteLine("Inserire qualsiasi valore nella lista; EXIT per terminare l'inserimento");
                        Console.WriteLine("");
                        valore_lista = Console.ReadLine();
                        while (valore_lista!="EXIT")
                        {
                            lista_generica.Add(valore_lista);
                            Console.WriteLine("");
                            valore_lista = Console.ReadLine();
                        }
                        do
                        {
                            Console.WriteLine("Inserire l'indice n-ultimo elemento da ricavare");
                            Console.WriteLine("");
                            try
                            {
                                n_ultimo = Convert.ToInt32(Console.ReadLine());
                                list_index = false;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Valore non numerico");
                                Console.WriteLine(e);
                                Console.WriteLine("");
                                list_index = true;
                            }
                            if (n_ultimo < 1)
                            {
                                Console.WriteLine("L'indice deve essere maggiore di 0");
                                Console.WriteLine("");
                                list_index = true;
                            }
                            ret_es_2 = Esercizio2(n_ultimo, lista_generica);
                            if (ret_es_2 == -1)
                            {
                                Console.WriteLine("L'indice inserito è superiore alla dimensione massima della lista");
                                Console.WriteLine("");
                                list_index=true;
                            }

                        } while (list_index==true);
                       
                        
                        Console.WriteLine("");
                        Console.Write("Il valore è: ");
                        Console.WriteLine(lista_generica[ret_es_2]);
                        Console.WriteLine("");
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Selezione non valida");
                        Console.WriteLine("");
                        break;
                }
            } while (exit == false);
            
        }

        static int[] Esercizio1(int n)
        {
            //creo l'array di dimensione N, di default è fillato con tutti i valori a 0
            int[] array_random = new int[n];
            //numero casuale
            int random_n;
            //condizione di check 
            bool check = true;
            //oggetto della classe Random per la generazione dei numeri casuali
            Random rd = new Random();
            //ciclo for per fillare l'array
            for (int i = 0; i < n; i++)
            {
                //ciclo do...while per generare il numero casuale da inserire nel vettore
                //la scenta del do è dovuta al fatto che, nella migliore delle ipotesi, almeno un numero
                //casuale deve essere generato e iserito nel vettore
                do
                {
                    check = true;
                    //genero un nuero casuale tra 0 e n
                    random_n = rd.Next(0, n+1);
                    //controllo se nell'array è già presente il valore generato dal numero casuale
                    foreach (int y in array_random)
                    {
                        if (y == random_n)
                        {
                            //se esiste devo ripetere il ciclo
                            check = false;
                        }
                    }
                    //se invece il numero non è già presente al suo interno...
                    if (check == true)
                    {
                        //...lo assegno all'i-esimo indice
                        array_random[i] = random_n;
                    }
                } while (check == false);
                //il ciclo si ripete fintanto che il numero casuale generato è già
                //presente nell'array
                //Poichè l'array all'inizio è inizializzato con tutti i valori a 0 ( essendo vettore di interi)
                //la generazione del numero casuale 0 comporta la falsità della condizioe per l'i-esimo indice
                //pertanto impedisce che si inserisca tale valore come valido all'interno del vettore
            }
            //proseguo con tutti gli indici N dell'array finale
            Console.Write("");
            Console.Write("Il vettore generato è ");
            Console.Write("");
            //ciclo di stampa del vettore casuale generato
            for (int j = 0; j < n; j++)
            {
                Console.Write(array_random[j] + " ");
            }
            return array_random;
         
        }

        static int Esercizio3(string path, string word)
        {
            int count = 0;
            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    string libro = stream.ReadToEnd();
                    count = libro.IndexOf(word);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine("Il file non può essere aperto, oppure non esiste");
                Console.WriteLine(e.Message);
            }
            return count;

        }

        static int Esercizio2(int n_ultimo, List<object> lista)
        {
            int index = 0;
            foreach(object i in lista)
            {
                index++;
            }
            if (index - n_ultimo < 1)
            {
                return -1;
            }
            else
            {
                return index - n_ultimo;
            }
            
        }
    }
 }
