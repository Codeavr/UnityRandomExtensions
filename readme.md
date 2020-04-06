Unity Random Extensions
===

## Features
* Random item access
  ```c#
  items.PickRandom()
  ```
* Array creation without repetitions in row
  ```c#
  var items = new [] { "general", "there", "hello", "kenobi" };

  var randomized = RandomUtils.GenerateNonRepeatingRandomArray(items, 10);

  print(string.Join(", ", randomized)); // general, kenobi, there, kenobi, hello, there, general, kenobi, hello, there
  ```
* Weighted random
  ```c#
  var items = new [] { "general", "there", "hello", "kenobi" };

  var weights1 = new float[] { 0, 0, 1, 0 };
  var weights2 = new float[] { 0, 1, 0, 0 };
  var weights3 = new float[] { 1, 0, 0, 0 };
  var weights4 = new float[] { 0, 0, 0, 1 };

  print(RandomUtils.GetWeightedRandomElement(items, weights1)); // hello
  print(RandomUtils.GetWeightedRandomElement(items, weights2)); // there
  print(RandomUtils.GetWeightedRandomElement(items, weights3)); // general
  print(RandomUtils.GetWeightedRandomElement(items, weights4)); // kenobi
  ```


## Install

Find `Packages/manifest.json` in your project and edit it to look like this:
```json
{
  "dependencies": {
    "com.codeavr.unity-random-extensions": "https://github.com/Codeavr/UnityRandomExtensions.git"
  }
}
```


### Requirements

* Unity any version
* Git

## License

* MIT
