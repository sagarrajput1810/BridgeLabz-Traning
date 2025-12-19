using System;
class ProfileLoss{
	static void Main(){
		int cost = 129;
		int price = 191;
		Console.WriteLine("The Cost Price is INR " + cost +" and Selling Price is INR " + price);
		Console.WriteLine("The Profit is INR " + (price - cost)+" and the Profit Percentage is " + ((double)(price - cost) /cost * 100));
	}
}