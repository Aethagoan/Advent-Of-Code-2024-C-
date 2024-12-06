// AIDAN ANDERSON DEC 2024 :)


namespace AdventOfCode;

class day4 {

	static void Main() {

		string[] lines =  File.ReadAllLines("../Advent Inputs/day4input.txt");

		string xmas = "XMAS";
		string samx = "SAMX";

		int numofxmas = 0;

		Console.WriteLine("\nLINES");
		foreach (string line in lines){
			Console.WriteLine(line);
		}

		// line by line
		for (int i = 0; i < lines.Length; i++){
			// dumb idea, what if I split the string by xmas and samx seperately, count the length of a split list - 1 should give me the count
			numofxmas += (lines[i].Split(xmas).Length - 1);
			numofxmas += (lines[i].Split(samx).Length - 1);
		}

		// how do I get a list of the columns?
		string[] columns = new string[lines[0].Length];

		for (int i = 0; i < columns.Length; i++){
			for (int j = 0; j < lines.Length; j++){
				columns[i] += lines[j][i];

			}
		}

		Console.WriteLine("\nCOLUMNS");
		foreach (string line in columns){
			Console.WriteLine(line);
		}

		// column by column
		for (int i = 0; i < lines.Length; i++){
			// dumb idea, what if I split the string by xmas and samx seperately, count the length of a split list - 1 should give me the count
			numofxmas += (columns[i].Split(xmas).Length - 1);
			numofxmas += (columns[i].Split(samx).Length - 1);
		}

		// how do I get a list of the diagonals?
		string[] forward_diagonals = new string[lines.Length + lines[0].Length - 1];

		for (int i = 0; i < lines[0].Length; i++) {
			// go until it reaches outside the array :D
			try {
				int k = i;
				while (true){
					forward_diagonals[i] += lines[k-i][k];
					k++;
				}
			} catch {

			}
			
		}

		for (int i = 0; i < lines.Length; i++){
			try {
				int k = i;
				while (true){
					forward_diagonals[lines[0].Length + i] += lines[k+1][k-i];
					k++;
				}
			}
			catch {

			}
		}

		Console.WriteLine("\nFORWARD DIAGS");
		foreach (string line in forward_diagonals){
			Console.WriteLine(line);
		}

		// forward diagonal by forward diagonal
		for (int i = 0; i < forward_diagonals.Length; i++){
			numofxmas += (forward_diagonals[i].Split(xmas)).Length - 1;
			numofxmas += (forward_diagonals[i].Split(samx)).Length - 1;
		}



		string[] backward_diagonals = new string[lines.Length + lines[0].Length - 1];

		for (int i = 0; i < lines[0].Length; i++) {

			try {
				int k = i;
				while (true){
					backward_diagonals[i] += lines[i-k][k];
					k--;
				}
			} catch {

			}
			
		}

		for (int i = 0; i < lines.Length; i++){
			try {
				int k = 0;
				// Console.WriteLine();
				while (true){
					backward_diagonals[lines[0].Length + i] += lines[k+1+i][lines[0].Length - (k+1)];
					// Console.Write(lines[k+1+i][lines[0].Length - (k+1)]);
					k++;
				}
			}
			catch {

			}
		}

		Console.WriteLine("\nBACKWARDS DIAGS");
		foreach (string line in backward_diagonals){
			Console.WriteLine(line);
		}

		// backward diagonal by backward diagonal
		for (int i = 0; i < backward_diagonals.Length; i++){
			try {
				numofxmas += (backward_diagonals[i].Split(xmas)).Length - 1;
				numofxmas += (backward_diagonals[i].Split(samx)).Length - 1;
			}
			catch {

			}
			
		}

		Console.WriteLine($"Number of xmas: {numofxmas}");


		//////// PART TWO ///////////////

		int numofmasx = 0;

		List<(int,int)> A_Locations = new();

		// find all the a's on the inner portion.
		for (int i = 1; i < lines.Length-1; i++){
			for (int j = 1; j < lines[0].Length-1; j++){
				if (lines[i][j] == 'A'){
					(int,int) t = (i,j);
					A_Locations.Add(t);
				}
			}
		}

		// look at every a in this set, opposite corners must contain both an S and an M.
		foreach ((int,int) position in A_Locations){
			if( (lines[position.Item1+1][position.Item2+1] == 'M' && lines[position.Item1-1][position.Item2-1] == 'S' || 
			lines[position.Item1+1][position.Item2+1] == 'S' && lines[position.Item1-1][position.Item2-1] == 'M') && 
			(lines[position.Item1+1][position.Item2-1] == 'M' && lines[position.Item1-1][position.Item2+1] == 'S' || 
			lines[position.Item1+1][position.Item2-1] == 'S' && lines[position.Item1-1][position.Item2+1] == 'M')){
				// count it!
				numofmasx ++;
			}
		}

		Console.WriteLine($"Number of mas-x's: {numofmasx}");
	


	}// end main
}