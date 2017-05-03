# FastString
Alternative to the StringBuilder class for Unity games, with minimal memory allocation and faster performance.
Based on [FastString](https://www.reddit.com/r/Unity3D/comments/3zz62z/alternative_to_stringbuilder_without_memory/) by Nicolas Gadenne of [Gaddy Games](http://gaddygames.com/site/)

The class has been designed to be most useful in common game situations: a concatenation of a few string and data, then used by a Unity api method as an immutable string - every frame. 
It handles Append() and Replace() without doing any allocation, except for very rare capacity augmentation (contrary to StringBuilder which surprisingly does capacity change very often). 
It also appends float and int numbers without any allocation. 

The only common memory allocation is when you retrieve the final immutable string - but this is only done when required.

# Running the tests

A Unity project is provided for testing the performance.

- To run the performance tests, open the FastStringTest scene and the Profiler ( Window > Profiler ).
- Run the scene in the editor and then stop it again.
- Enter 'Test' in the profile search to see the profile results for each technique.
