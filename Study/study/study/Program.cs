
Task Test()
{
    Console.WriteLine("Start Test");
    Task t = Task.Delay(3000);
    return t;
}

async Task TestAsync()
{
    Console.WriteLine("Start TestAsync");
    await Task.Delay(3000);
    /*Task t = Task.Delay(3000);
    await t;*/

    Console.WriteLine("End TestAsync");
}

await TestAsync();

Console.WriteLine("while start");
while (true)
{

}
