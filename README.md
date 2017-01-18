# MD5reborn
Multithreaded application to create your own rainbow tables in any hashing algorithm. It has two version one written in c# and the other in c++. It is recommended to use the c++ version since it is much faster.

## What it does
This program will create a rainbow table from scratch and can pick up where you left it.
Should be compatible with any hashing algorithm. Currently MD5, SHA256

## Current state
* When given a blank folder the program can start creating files from scratch. These files contain 12Million lines a word starting from "a" and its hash (currently MD5 and AES256 only)
* When the program is restarted it can pick up at the word it last hashed
* Different hashing algorithms
* Currently this program works in linux mono. Be carefull that line endings are different so windows created files are not compatible.
* Load balancing: Give up multiple destinations for your data. Writing from 16 Threads to one Hardrive might be a problem.
* A speedy c++ port.
* Linux support for c# and c++ (c++ line endings are currently always "\n")

## Future features
* Add options to choose line ending.
* More command line options: So you can choose ToDisk format (example: instead of writing to a file you write directly to a database).
* Performance tweaks: In the ToDisk section
* Better Debug data
* Console info and possibly commands
* Load balancing with master slave -> so a master sends out jobs to slaves over tcp. Working example is another project of mine  **MD5_V4.0**. You might want to pull a older verion newest one does not work.
* **Crazy** When there is nothing left why not add gpu acceleration :) if we ever get there.

## How to use
Clone the repo -> compile binary -> create an empty folder on a drive -> run the program with arguments.
C++ requires extra binaries. openSSL (1.1.0c) and boost (1.63.0)

### current arguments

- arg0: [Path] : D:\\test\
- argN: [Path] : E:\\extra\drive\  You can add as many dives as you like.
- argN+1: [HashAlgoritm] : MD5 : SHA256

## Why
I like multithreading.
