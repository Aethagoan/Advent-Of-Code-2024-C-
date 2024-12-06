// AIDAN ANDERSON DEC 2024 :)


using System.Numerics;
namespace AdventOfCode;

class day6 {


    static void Main() {

		string[] lines = File.ReadAllLines("../Advent Inputs/day6input.txt");

        char[][] map = new char[lines.Length][];

        for (int o = 0; o < lines.Length; o++){
            map[o] = lines[o].ToCharArray();
        }
        
        int x = 0;
        int y = 0;

        for (int y_ = 0; y_ < map.Length; y_++) {
            for (int x_ = 0; x_ < map[y_].Length; x_++) {
                if (map[y_][x_] == '^') {
                    x = x_;
                    y = y_;
                    goto ExitFindPosition;
                }
            }
        }
        throw new Exception("AAAAAAAAAAAAAH");
        // Labels :D
        ExitFindPosition:

        (int,int) originalposition = (x,y);

        (int,int) currentPosition = originalposition;
        char movechar = '^';

        (int,int) UP = (0,-1);
        (int,int) RIGHT = (1,0);
        (int,int) DOWN = (0,1);
        (int,int) LEFT = (-1,0);

        (int,int) currentVector = UP;

        void turn(){
            if (currentVector == UP){
                currentVector = RIGHT;
                movechar = '>';
            }
            else if (currentVector == RIGHT) {
                currentVector = DOWN;
                movechar = 'v';
            }
            else if (currentVector == DOWN) {
                currentVector = LEFT;
                movechar = '<';
            }
            else {
                currentVector = UP;
                movechar = '^';
            }
        }

        int uniquesteps = 1;
        
        // turn the current position into a X
        map[currentPosition.Item2][currentPosition.Item1] = 'X';

        try {
            while (true){
                if (map[currentPosition.Item2][currentPosition.Item1] == '.') {
                    uniquesteps++;
                    map[currentPosition.Item2][currentPosition.Item1] = movechar;
                }
                while (map[currentPosition.Item2+currentVector.Item2][currentPosition.Item1+currentVector.Item1] == '#') turn();
                currentPosition.Item1 += currentVector.Item1;
                currentPosition.Item2 += currentVector.Item2;
            }
        }
        catch (Exception ex){Console.WriteLine(ex);}
        // exit when we try to reach outside of the arrays.


        foreach (char[] line in map){
            Console.WriteLine();
            foreach (char pos in line){
                Console.Write(pos);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"unique positions: {uniquesteps}");


        ///////////// PART TWO /////////


        // reset map
        for (int o = 0; o < lines.Length; o++){
            map[o] = lines[o].ToCharArray();
        }
        

        
        int numofloops = 0;
        
        for (int iy = 0; iy < map.Length; iy++){

            for (int ix = 0; ix < map[iy].Length; ix++){

                Console.WriteLine($"on position ({ix},{iy})");

                // copy the map. . . need to do this alot.
                char[][] mapcopy = new char[map.Length][];
                Array.Copy(map, mapcopy, map.Length);



                // reset position direction
                currentPosition = originalposition;
                currentVector = UP;
                movechar = '^';

                // if this position is # or ^, skip!
                if (mapcopy[iy][ix] == '#' || mapcopy[iy][ix] == '^') continue;

                // block!
                mapcopy[iy][ix] = '#';

                // move once to avoid proc'ing
                while (mapcopy[currentPosition.Item2+currentVector.Item2][currentPosition.Item1+currentVector.Item1] == '#') turn();    
                    
                currentPosition.Item1 += currentVector.Item1;
                currentPosition.Item2 += currentVector.Item2;

                // begin moving!
                try {
                    while (true){
                        // if we ever are moving over a space, and it matches our movechar, we're in a loop!
                        if (mapcopy[currentPosition.Item2][currentPosition.Item1] == movechar) {
                            numofloops++;
                            break;
                        }
                        if (mapcopy[currentPosition.Item2][currentPosition.Item1] == '.') {
                            mapcopy[currentPosition.Item2][currentPosition.Item1] = movechar;
                        }
                        
                        while (mapcopy[currentPosition.Item2+currentVector.Item2][currentPosition.Item1+currentVector.Item1] == '#') turn();
                            
                        currentPosition.Item1 += currentVector.Item1;
                        currentPosition.Item2 += currentVector.Item2;
                    }
                }
                catch{}
                // exit when we try to reach outside of the arrays.


            }

        }

        Console.WriteLine($"number of loops found: {numofloops}");


    }
}