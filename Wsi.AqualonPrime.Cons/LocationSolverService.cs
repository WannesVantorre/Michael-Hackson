namespace Wsi.AqualonPrime.Cons
{
    public class LocationSolverService
    {
        public void Calculate()
        {
            string commando = "Up 7,Down 3,Forward 9,Down 8,Down 3,Up 9,Down 9,Down 7,Down 7,Down 4,Up 8,Down 8,Forward 7,Down 2,Forward 8,Up 4,Down 3,Down 8,Down 9,Down 2";
            string[][] listOfCommandos = commando.Split(',').Select(s => s.Split(' ')).ToArray();

            int totalSteps = 0;
            int currentHeight = 0;
            List<int> heights = new List<int>();
            int distance = 0;


            foreach (string[] command in listOfCommandos)
            {
                string direction = command[0];
                int steps = int.Parse(command[1]);

                switch (direction)
                {
                    case "Up":
                        currentHeight += steps;
                        break;
                    case "Down":
                        currentHeight -= steps;
                        break;
                    case "Forward":
                        totalSteps += steps;
                        break;
                    default:
                        Console.WriteLine("Unknown direction: " + direction);
                        break;
                }

                heights.Add(currentHeight);
            }

            // Calculate the distance
            for (int i = 0; i < heights.Count; i++)
            {
                if (i == 0)
                {
                    distance = totalSteps * heights[i];
                }
                else
                {
                    distance += heights[i];
                }
            }

            Console.WriteLine("Total Distance: " + distance);
        }

    }
}
