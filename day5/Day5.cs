// AIDAN ANDERSON DEC 2024 :)

using System;
using System.Collections.Generic;

namespace AdventOfCode;

class day5 {




    static void Main(){

		string[] lines = File.ReadAllLines("../Advent Inputs/day5input.txt");

        List<string> priorities = new();
        List<string> updates = new();

        int i = 0;
        while (lines[i] != ""){
            priorities.Add(lines[i]);
            i++;
        }
        i++;
        while ( i < lines.Length) {
            updates.Add(lines[i]);
            i++;
        }


        // foreach(var thing in priorities){
        //     Console.WriteLine(thing);
        // }




        Dictionary<string,List<string>> rules = new();

        foreach (string order in priorities){
            
            var set = order.Split("|");
            try {
                rules.Add(set[0], new List<string>());
            }
            catch {}

            rules[set[0]].Add(set[1]);

        }

        // foreach (var entry in rules){
        //     Console.WriteLine();
        //     Console.Write($"{entry.Key}: ");
        //     foreach (var str in entry.Value){
        //         Console.Write($"{str} ");
        //     }
        // }

        // Console.WriteLine();

        // foreach(var thing in updates){
        //     Console.WriteLine(thing);
        // }

        List<string> goodlines = new();

        foreach (string line in updates){

            var updatearray = line.Split(",");
            bool validline = true;

            for (int j = 1; j < updatearray.Length; j++){

                for (int k = j - 1; k >= 0; k--) {

                    try {
                        if (rules[updatearray[j].ToString()].Contains(updatearray[k])){

                            validline = false;
                            break;
                        }
                    }
                    catch {}

                    if (!validline) break;

                }

            }

            if (validline) {
                goodlines.Add(line);
            }

        }

        int accumulator = 0;
        Console.WriteLine();

        foreach (string line in goodlines){

            // Console.WriteLine(line);
            var delimited = line.Split(",");
            accumulator += int.Parse(delimited[(delimited.Length/2)]);
            // Console.WriteLine(delimited[(delimited.Length/2)]);
            

        }

        Console.WriteLine($"Accumulator 1: {accumulator}");



        ////////////////// PART TWO ///////////////////

        int accumulator2 = 0;


        foreach (var line in updates){
            Console.WriteLine();
            Console.Write($"   {line}");

            var updatearray = line.Split(",");

            for (int j = 1; j < updatearray.Length; j++){

                for (int k = 0; k < j; k++) {

                    if (rules[updatearray[j].ToString()].Contains(updatearray[k])){

                        // swap j and k and restart.
                        string temp = updatearray[j];
                        updatearray[j] = updatearray[k];
                        updatearray[k] = temp;
                        j = 1;
                        Console.Write($"\n-> {string.Join(",", updatearray)}");
                        break;
                    }


                }

                

            }

            // should be organized now
            Console.Write($"\n   {string.Join(",", updatearray)}");
            Console.WriteLine();

            accumulator2 += int.Parse(updatearray[updatearray.Length/2]);


        }


        Console.WriteLine($"Accumulator 2: {accumulator2}");


    }
}