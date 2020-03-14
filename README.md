# Object Pooling (Unity / C#)

![Object Pooling Image](/doc/object_pooling.gif)

## What is it?

A rudimentary pooling system using GameObjects which I created as a learning experience. 

Pooling is done using GameObjects with Pool script. These generate a predefined amount of reusable items of assigned type. When game needs a specific object type instead of using Instantiate, item can be spawned from object pool. When item is removed, instead of Destroy its despawn method is called to return it back to its owner pools reusable items.

## Code

Included scripts contain the pooling system and example scripts showing how to setup pooling in practice.

Note - no project files, sprites or animation classes included.

# Classes

## IPoolable.cs
An interface defining the only method needed in pooled items, Despawn. Each pooled object should have this method, and it should disable the GameObject after it has been used, instead doing typical Destroy(gameObject).

## Pool.cs
Pool class that generates instances, use SpawnObject to get an instance from pool.

## Other classes
Player ship, enemy ship and bullet classes - these classes show how spawning and despawning is done.

# Copyright
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
