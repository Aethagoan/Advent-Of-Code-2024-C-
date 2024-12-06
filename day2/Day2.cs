// AIDAN ANDERSON DEC 2024 :) 

using System;
using System.IO;

namespace AdventOfCode;

class day2 {

    static string[] lines_of_levels = File.ReadAllLines("../Advent Inputs/day2input.txt");

    static void Main() {
        
        //////////// PART ONE ////////////////

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


        Console.WriteLine($"Good reading count 1: {reading_count}");

		//////////////////// PART TWO /////////////////////////
		
		reading_count = 0;

        for (int i = 0; i < lines_of_levels.Length; i++) {

            List<int> single_line = new();

			string[] splitline = lines_of_levels[i].Split(" ");

			for (int l = 0; l <splitline.Length; l++){
				single_line.Add(int.Parse(splitline[l]));
			}

			// Console.WriteLine(PrintLine(single_line));
		
			if(checkRecursion(single_line)){
				// Console.WriteLine(" passed.");
				reading_count++;
			}

		}// end for

		Console.WriteLine($"Good reading count 2: {reading_count}");


		string PrintLine(List<int> thelist){
			string adder = "";
			adder += thelist[0];
			for (int i = 1; i < thelist.Count; i++){
				adder += $" {thelist[i]}";
			}
			return adder;
		}

        // checks
		static bool checkRecursion(List<int> thelistofints){
            
			for (int i = 0; i < thelistofints.Count+1; i++){
                // load list minus the next thing
                List<int> modified = new List<int>();
                
                // try removing this iteration's id
				if (i > 0) {
					for (int l = 0; l < thelistofints.Count; l++){
                    	if (l == i-1) continue;
                    	modified.Add(thelistofints[l]);
                	}
				}
                
                
                // check validity
                bool valid = true;

				bool ascending = true;
				if (modified.Count < 2) continue;
				if (modified[0] > modified[1]) ascending = false;
				if (modified[0] == modified[1]) continue;

                for (int j = 0; j < modified.Count - 1; j++){

                    // equal is bad
                    if (modified[j] == modified [j+1]){
                        valid = false;
                        break;
                    }

                    if (ascending){
                        // ascending
                            // if we descend, this is a bad reading!
                        if (modified[j] > modified[j + 1]){
                            valid = false;
                            break;
                        } 
                            // if the difference is more than three, bad reading!
                        if (Math.Abs(modified[j] - modified[j + 1]) > 3) {
                            valid = false;
                            break;
                        } 
                    } 
                    else {
                        // descending
                            // if we ascend this is a bad reading!
                        if (modified[j] < modified[j + 1]){
                            valid = false;
                            break;
                        } 
                            // if the difference is more than three, bad reading!
                        if (Math.Abs(modified[j]) - modified[j + 1] > 3){
                            valid = false;
                            break;
                        } 
                    }


                }// end for j

                if (valid) {
					// PrintLine(thelistofints);
					// Console.WriteLine($"Modified to {PrintLine(modified)}");
					// Console.WriteLine();
                    return true;
                }

            } // end for i
			
			return false;
		}

        //////////////////// PART TWO ////////////////















        

    }// end main
}