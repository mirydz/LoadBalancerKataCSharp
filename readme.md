# LoadBalancerKataCSharp

see also: https://github.com/mto-lab/loadBalancerKataMto
This is kata like excercise based on https://github.com/cletourneau/iweb-demo-kata to teach TDD.

Notes:

* This project was created using Microsoft Visual Studio 15
* Targets .Net Framework 4.6

The unit tests are written using [NUnit framework](http://www.nunit.org/index.php?p=home).  
At the time of writing the tests NUnit v.2.6.4 was used.

The project uses a few features from C# 6 such as:
* Using statements for static members (simmilar to static imports in Java)
* Null-conditional operator (easier null checking)

See https://github.com/dotnet/roslyn/wiki/New-Language-Features-in-C%23-6 for more info about changes in C#.

To make the tests resemble the Java implementation from https://github.com/mto-lab/loadBalancerKataMto, NUnit's constraint mechanism was used so that the Java code:

```java
@Test
public void balancingAServer_noVms_serverStaysEmpty() {
	Server theServer = a(server().withCapacity(1));

	balance(aListOfServersWith(theServer), anEmptyListOfVms());

	assertThat(theServer, hasLoadPercentageOf(0.0d));
}

private Matcher<? super Server> hasLoadPercentageOf(double expectedLoadPercentage) {
	return new CurrentLoadPercentageMatcher(expectedLoadPercentage);
}
```
Has its C# equivalent of:

```csharp
[Test]
public void BalancingServer_NoVms_ServerStaysEmpty()
{
	Server theServer = A(Server().WithCapacity(1));

	Balance(ListOfServersWith(theServer), EmptyListOfVms());

	Assert.That(theServer, HasLoadPercentageOf(0.0));
}

private Constraint HasLoadPercentageOf(double expectedLoadPerentage)
{
	return new CurrentLoadPercentageConstraint(expectedLoadPerentage);
}
```

For more information on how to make custom constraints visit the following links:
* http://www.nunit.org/index.php?p=customConstraints&r=2.5.10 (official NUnit docs)
* http://www.davidarno.org/2012/07/23/using-custom-constraints-to-improve-nunit-test-quality-part-1-of-2/
* http://www.davidarno.org/2012/07/24/using-custom-constraints-to-improve-nunit-test-quality-part-2-of-2/
* http://www.cafe-encounter.net/p542/nunit-constraints-example-custom-constraint#gsc.tab=0

