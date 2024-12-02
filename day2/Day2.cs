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


        Console.WriteLine($"Good reading count 1: {reading_count}");

		//////////////////// PART TWO /////////////////////////
		
		reading_count = 0;

        for (int i = 0; i < lines_of_levels.Length; i++) {

            List<int> single_line = new();

			string[] splitline = lines_of_levels[i].Split(" ");

			for (int l = 0; l <splitline.Length; l++){
				single_line.Add(int.Parse(splitline[l]));
			}

			bool ascending = true;
			bool undamaged = true;
			bool good_reading = true;

			// check initial
			if (single_line[0] > single_line[1]){
				// descending
				ascending = false;
			}
			else if (single_line[0] < single_line[1]) {
				// ascending
			}
			else {
				// equal. Problem area. identify possible solution.
				// look at 2, if it is valid off of this, remove the first element and then continue, else just reject.
				if (Math.Abs(single_line[0] - single_line[2]) > 3) continue;
				// otherwise, we remove one element and move on also marking as damaged
				undamaged = false;
			}
			

			// on this line
			for (int j = 0; j < single_line.Count -1; j++){

				// at j, we look at the next thing
				if (ascending){
					// look at j+1, if there's an issue. . .
					// if j+1 descends, just get rid of it. unless we already have damage in which case break
					if (single_line[j] > single_line[j+1]){
						if (undamaged){
							single_line.RemoveAt(j+1);
							j--;
							undamaged = false;
						}
						else {
							good_reading = false;
							break;
						}
					}
					// if there is a discrepancy in value. . .


				}
				else {

				}
			}




		}// end for

		Console.WriteLine($"Good reading count 2: {reading_count}");


		void PrintLine(List<int> thelist){
			Console.WriteLine();
			foreach (int thing in thelist){
				Console.Write($"{thing} ");
			}
		}

		bool checkRecursion(List<int> thelistofints){

			for (int i = 0; i < thelistofints.Count; i++)
			

			return false;
		}

    }// end main
}