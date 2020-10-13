## Code Of Conduct

### Comments
All comments will follow the Javadoc / Doxygen coding standard which can be written as below.

```java
/**
 * {DESCRIPTION}
 * @author {AUTHOR}
 * @date {DD-MM-YYYY}
 */
```

### Naming Conventions

We will use the standardised C# way of naming our code which means that all private **fields** will start with an underscore and then follow the camelCase.

It also means that we will use PascalCase for **methods** and **properties** that aren't private where the **methods** ALWAYS will be PascalCase.

##### Examples
```csharp

private readonly uint _id;

public void MyFunction() {}

protected uint Id => _id;

```
