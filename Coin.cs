using System;

public class Coin
{
	public string name {  get; set; }
	public double price { get; set; }
	public int income { get; set; }
	public byte[]? icon { get; set; }
	
	public Coin(string name, double price, int income)
	{
		this.name = name;
		this.price = price;
		this.income = income;
	}

    public Coin(string name, double price, int income, byte[] icon)
    {
        this.name = name;
        this.price = price;
        this.income = income;
		this.icon = icon;
    }
}
