using System;
using System.Linq;
using System.Collections.Generic;

namespace Katla_Assistant
{
    class Program
    {
        static void Main(string[] args)
        {
            //dict
            Console.WriteLine("Katla / Wordle ?");
            var dict = Console.ReadLine();
            string[] LogFile = {"a"};

            if(dict=="katla"||dict=="Katla"||dict=="k"||dict=="K"){
                LogFile = System.IO.File.ReadAllLines(@"DataKatla.txt");
                Console.WriteLine("Anda memilih Katla");
            }
            else if(dict=="wordle"||dict=="Wordle"||dict=="w"||dict=="W"){
                LogFile = System.IO.File.ReadAllLines(@"DataWordle.txt");
                Console.WriteLine("Anda memilih Wordle");
            }
            else{
                Console.WriteLine("Inputan salah, Program berhenti");
                Environment.Exit(0);
            }

            List<string> data = new List<string>(LogFile);

            string guess;
            string color;

            // run prefix

            while(true){
                //input user
                Console.Write("Masukan kata : ");
                guess = Console.ReadLine();
                if(guess=="."){
                    Console.WriteLine("Program berhenti");
                    Environment.Exit(0);
                }

                Console.Write("Warna huruf : ");
                color = Console.ReadLine();
                if(color =="."){
                    Console.WriteLine("Program berhenti");
                    Environment.Exit(0);
                }

                //algorithm
                for (int i=0; i < 5; i++){
                    if (color[i]=='g' || color[i]=='G'){
                        for(int j=data.Count -1 ; j>=0 ; j--){
                            if (guess[i]!=data[j][i]){
                                data.RemoveAt(j);
                            }

                        }
                    }
                    if (color[i]=='y' || color[i]=='G'){
                        for(int j=data.Count -1 ; j >=0 ; j--){
                            if (!data[j].Contains(guess[i])){
                                data.RemoveAt(j);
                            }
                        }
                    }
                    if (color[i]=='b' || color[i]=='B'){
                        for(int j=data.Count -1 ; j >= 0 ; j--){
                            if (data[j].Contains(guess[i])){
                                data.RemoveAt(j);
                            }
                        }
                    }
                }
                //output
                for(int i =0;i<data.Count;i++){
                    if(i==data.Count-1){
                        Console.Write(data[i]);
                    }
                    else{
                        Console.Write(data[i] + ", ");
                    }
                }
                Console.Write("\n");
            }

        }
    }
}
