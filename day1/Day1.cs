// AIDAN ANDERSON 1 DEC 2024 :) 
using System;
using System.IO;

namespace AdventOfCode;

class day1 {

    static void Main(){

        //INITIALIZATION ///////////////////////////////////////
        
        string[] inputday1 = File.ReadAllLines("../Advent Inputs/day1input.txt");

        // foreach (string line in inputday1){
        //     Console.WriteLine(line);
        // }

        string[] list1 = new string[inputday1.Length];
        string[] list2 = new string[inputday1.Length];

        string[] bufferlist;

        for (int i = 0; i < inputday1.Length; i++) {

            bufferlist = inputday1[i].Replace("   ", " ").Split(" ");
            // Console.WriteLine($"{bufferlist[0]} {bufferlist[1]}");
            list1[i] = bufferlist[0];
            list2[i] = bufferlist[1];

        }

        Array.Sort(list1);
        Array.Sort(list2);

        //////////////// PART ONE ////////////////////

        int accumulator = 0;

        for (int i = 0; i < list1.Length; i++) {
            try {
                accumulator += Math.Abs(int.Parse(list1[i]) - int.Parse(list2[i]));

            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        Console.WriteLine($"Part1 answer: {accumulator}");

        ////////////// PART TWO ///////////////

        int similaritycounter = 0;
        int numberoftimesencountered;

        for (int i = 0; i < list1.Length; i++){
            numberoftimesencountered = 0;
            for (int j = 0 ; j < list2.Length; j++){
                if (int.Parse(list1[i]) == int.Parse(list2[j])){
                    numberoftimesencountered++;
                }
            }
            similaritycounter += int.Parse(list1[i]) * numberoftimesencountered;
        }

        Console.WriteLine($"Part2 answer: {similaritycounter}");
    }

}