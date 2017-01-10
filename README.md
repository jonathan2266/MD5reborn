# MD5reborn
Multithreaded C# application to create your own rainbow tables in any hashing algorithm.

## What it does
This program will create a rainbow table from scratch and can pick up where you left it.
Should be compatible with any hashin algoritm.

##Current state
When given a blank folder the program can start creating files from scratch. These files contain 12Million lines a word starting from "a" and its hash (currently MD5 only)

## Future features
* More command line options: So you can choose ToDisk format (example: instead of writing to a file you write directly to a database).
* Diffrent hashing algorithms: like sha, ..
* Load balancing: Give up multiple destinations for your data. Writing from 16 Threads to one Hardrive might be a problem.
* Performance tweaks: In the ToDisk section Also when this project is completed a c++ port could potentially speed up everything.
* Better Debug data
* Ability to pick up from where the program left last time.
* Linux support for c# and c++
* Console info and possibly commands
* Load balancing with master slave -> so a master sends out jobs to slaves over tcp. Working example is another project of mine  **MD5_V4.0**. You might want to pull a older verion newest one does not work.
* **Crazy** When there is nothing left why not add gpu acceleration :) if we ever get there.

## How to use
Clone the repo -> compile binary -> create an empty folder on a drive -> run the program with as argument the path Ex. D:\\test\

## Why
I like multithreading.