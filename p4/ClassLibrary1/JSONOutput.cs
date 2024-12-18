﻿//Derrick Nguyen
//JSONOutput.cs
//Writes orders to JSON file
using System.Text.Json;
//inherits output handler in order to create output 
public class JSONOutput : OutputHandler
{
    public void WriteOrder(Order order)
    {
        string json = JsonSerializer.Serialize(order, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("order.json", json);
    }
}