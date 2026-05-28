
using System.Globalization;

class RoadTripSummary
{
    static void Main()
    {
        CultureInfo ci = CultureInfo.InvariantCulture;

        Console.WriteLine("We are going to map out a road trip for Fall Break. I'm going to ask you some specific questions about the trip, and then I'll calculate a trip summary from that information.");

        Console.Write("Where will you be driving? ");
        string destination = Console.ReadLine() ?? "";

        Console.Write("Who will be driving? ");
        string driver = Console.ReadLine() ?? "";

        Console.Write($"How many miles to get to {destination}? ");
        double distanceOneWay = double.Parse(Console.ReadLine() ?? "0", ci);

        Console.Write($"What average speed (MPH) will {driver} be travelling? ");
        double avgSpeed = double.Parse(Console.ReadLine() ?? "0", ci);

        Console.Write("How many MPG does your car get? ");
        double mpg = double.Parse(Console.ReadLine() ?? "0", ci);

        Console.Write("How many gallons of gas does your car hold? ");
        double tankGallons = double.Parse(Console.ReadLine() ?? "0", ci);

        Console.Write("Excluding the driver, how many riders in the car? ");
        int ridersExcludingDriver = int.Parse(Console.ReadLine() ?? "0", ci);

        Console.Write("What unit of currency ($, £, ¥, €) do you use? ");
        string currency = Console.ReadLine() ?? "$";

        Console.Write($"What is the fuel price per gallon ({currency})? ");
        double pricePerGallon = double.Parse(Console.ReadLine() ?? "0", ci);

        // Calculations
        double roundTripDistance = distanceOneWay * 2.0;
        double oneWayHours = avgSpeed > 0 ? distanceOneWay / avgSpeed : 0.0;

        int hours = (int)Math.Floor(oneWayHours);
        int minutes = (int)Math.Round((oneWayHours - hours) * 60.0);
        if (minutes == 60) { hours += 1; minutes = 0; }

        double fuelNeededRoundTrip = roundTripDistance / mpg;
        double rangePerTank = tankGallons * mpg;
        int estimatedRefuels = 0;
        if (rangePerTank > 0)
        {
            estimatedRefuels = Math.Max(0, (int)Math.Ceiling(roundTripDistance / rangePerTank) - 1);
        }

        double fuelCost = fuelNeededRoundTrip * pricePerGallon;
        int totalPeople = ridersExcludingDriver + 1;
        double costPerPerson = totalPeople > 0 ? fuelCost / totalPeople : 0.0;

        double costPerMileTrue = roundTripDistance > 0 ? fuelCost / roundTripDistance : 0.0;
        double costPerHourLikeImage = oneWayHours > 0 ? fuelCost / oneWayHours : 0.0;

        Console.Write("Average song length (min): ");
        double avgSongLengthMin = double.Parse(Console.ReadLine() ?? "3.5", ci);
        int songsNeeded = (int)Math.Ceiling((oneWayHours * 60.0) / avgSongLengthMin);

        // Output (aligned)
        Console.WriteLine();
        Console.WriteLine("{0,-30}{1}", "Driver:", driver);
        Console.WriteLine("{0,-30}{1}", "Currency:", currency);
        Console.WriteLine("{0,-30}{1}", "Distance (miles):", distanceOneWay.ToString("F0", ci));
        Console.WriteLine("{0,-30}{1}", "Average Speed (mph):", avgSpeed.ToString("F0", ci));
        Console.WriteLine("{0,-30}{1}H {2}M", "Time Driving:", hours, minutes);
        Console.WriteLine();
        Console.WriteLine("{0,-30}{1}", "Vehicle Miles per Gallon:", mpg.ToString("F0", ci));
        Console.WriteLine("{0,-30}{1} gallons", "Fuel Needed (round trip):", fuelNeededRoundTrip.ToString("F2", ci));
        Console.WriteLine("{0,-30}{1}", "Range per tank:", rangePerTank.ToString("F0", ci));
        Console.WriteLine("{0,-30}{1}", "Estimated Fuel Stops:", estimatedRefuels);
        Console.WriteLine();
        Console.WriteLine("{0,-30}{1}", "Gas Price per gallon:", currency + pricePerGallon.ToString("F2", ci));
        Console.WriteLine("{0,-30}{1}", "Fuel Cost:", currency + fuelCost.ToString("F2", ci));
        Console.WriteLine("{0,-30}{1}", "Riders (split):", totalPeople);
        Console.WriteLine("{0,-30}{1} (+ snacks)", "Cost per person:", currency + costPerPerson.ToString("F2", ci));
        Console.WriteLine("{0,-30}{1}", "Cost per mile:", currency + costPerHourLikeImage.ToString("F2", ci));
        Console.WriteLine("{0,-30}{1}", "Cost per mile (true):", currency + costPerMileTrue.ToString("F2", ci));
        Console.WriteLine();
        Console.WriteLine("{0,-30}{1}", "Average song length (min):", avgSongLengthMin.ToString("F2", ci));
        Console.WriteLine("{0,-30}{1}", "Number of songs needed:", songsNeeded);

    
    }
}
