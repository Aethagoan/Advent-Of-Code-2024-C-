// AIDAN ANDERSON DEC 2024 :) 
using System;

namespace AdventOfCode;

class day3 {

	static void Main() {

    	string[] lines_of_levels = File.ReadAllLines("../Advent Inputs/day3input.txt");

		// combine the lines
		string fullstring = "";
		foreach (string line in lines_of_levels){
			fullstring += line;
		}

		//////////// ONE ////////////////////

		int accumulator = 0;

		var splitbymul = fullstring.Split("mul(");
		foreach (string mul in splitbymul){

			// if there isn't a ) its a problem
			if (!mul.Contains(")") || !mul.Contains(",")) continue;
			var newsplit = mul.Split(")");

			if (!newsplit[0].Contains(",")) continue;
			var lastsplit = newsplit[0].Split(",");

			// if this thing has more than just two things the data is borked because it got a section with multiple commas.
			if (lastsplit.Length > 2) continue;

			try {
				int first;
				int second;
				first = int.Parse(lastsplit[0]);
				second = int.Parse(lastsplit[1]);
				if ((first < 1000 && first > -1) && (second < 1000 && second > -1)) {
					accumulator += (first*second);
				}
			}
			catch (Exception ex){
				// Console.WriteLine(ex);
			}
			


		}

		Console.WriteLine($"Total 1: {accumulator}");

		////////////// TWO ///////////////


		accumulator = 0;

		// fixes a problem where the very first section wouldn't be considered.
		var temp = "don't()do()";
		temp += fullstring;
		fullstring = temp;

		var splitbydont = fullstring.Split("don't()");
		
		// now that we have the don't sections, we need to break it up by do's.
		// the first section will come following a dont, the following sections should be all dos.

		for (int j = 0; j < splitbydont.Length; j++){
			
			// Console.WriteLine();
			// Console.WriteLine();
			// Console.WriteLine();
			// Console.WriteLine();

			var splitbydos = splitbydont[j].Split("do()");
			
			// foreach (string split in splitbydos){
			// 	Console.Write($"{split}    DO HERE ->    ");
			// }
			// Console.WriteLine();

			// ignore the first element
	
			for (int i = 1; i < splitbydos.Length; i++){

				var splitbymul2 = splitbydos[i].Split("mul(");
				foreach (string mul in splitbymul2){

					// if there isn't a ) its a problem
					if (!mul.Contains(")") || !mul.Contains(",")) continue;
					var newsplit = mul.Split(")");

					if (!newsplit[0].Contains(",")) continue;
					var lastsplit = newsplit[0].Split(",");

					// if this thing has more than just two things the data is borked because it got a section with multiple commas.
					if (lastsplit.Length > 2) continue;

					try {
						int first;
						int second;
						first = int.Parse(lastsplit[0]);
						second = int.Parse(lastsplit[1]);
						if ((first < 1000 && first > -1) && (second < 1000 && second > -1)) {
							accumulator += (first*second);
						}
					}
					catch (Exception ex){
						// Console.WriteLine(ex);
					}
				}
			}

		



		}

		Console.WriteLine($"Total 2: {accumulator}");



	}// end main

}