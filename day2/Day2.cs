using System;
using System.IO;

namespace AdventOfCode;

class day2 {

    static string[] lines_of_levels = File.ReadAllLines("../Advent Inputs/day2input.txt");

    static void Main() {
        
        // for (int i = 0; i < lines_of_levels.Length; i++) {
        //     Console.WriteLine(lines_of_levels[i]);
        // }
        
        int reading_count = 0;

        for (int i = 0; i < lines_of_levels.Length; i++) {
            string[] single_line = lines_of_levels[i].Split(" ");
            bool ascending = true;
            bool good_reading = true;
            // for (int k = 0; k < single_line.Length; k++) {
            //     Console.Write($"'{single_line[k]}'");
            // }
            // Console.WriteLine();

            if (int.Parse(single_line[0]) > int.Parse(single_line[1])){
                // descending
                ascending = false;
            }
            else if (int.Parse(single_line[0]) < int.Parse(single_line[1])){
                // ascending 
                // no change
            } 
            else {
                // equal? bad reading.
                continue;
            }

            for (int j = 0; j < single_line.Length - 1; j++){

                // equal is bad
                if (single_line[j] == single_line [j+1]){
                    good_reading = false;
                    break;
                }

                if (ascending){
                    // ascending
                        // if we descend, this is a bad reading!
                    if (int.Parse(single_line[j]) > int.Parse(single_line[j + 1])){
                        good_reading = false;
                        break;
                    } 
                        // if the difference is more than three, bad reading!
                    if (Math.Abs(int.Parse(single_line[j]) - int.Parse(single_line[j + 1])) > 3) {
                        good_reading = false;
                        break;
                    } 
                } 
                else {
                    // descending
                        // if we ascend this is a bad reading!
                    if (int.Parse(single_line[j]) < int.Parse(single_line[j + 1])){
                        good_reading = false;
                        break;
                    } 
                        // if the difference is more than three, bad reading!
                    if (Math.Abs(int.Parse(single_line[j]) - int.Parse(single_line[j + 1])) > 3){
                        good_reading = false;
                        break;
                    } 
                }
            }// end for j

            // if we don't break we add accumulator
            if (good_reading){
                reading_count++;
            }
           
        }// end for i


        Console.WriteLine($"Good reading count: {reading_count}");

    }// end main
}