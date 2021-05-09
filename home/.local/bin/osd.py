#!/usr/bin/env python
from pathlib import Path

INPUT_FILE_PATH=str(Path.home())+"/osd"
MAX_LINE_LENGTH=64
OUTPUT_LINE_COUNT=8

def getlines():
    f = open(INPUT_FILE_PATH, "r")
    lines = f.readlines()
    lines.reverse()
    return lines
    
def removeblanks(list):
    for line in lines:
        if line.isspace():
            lines.remove(line)

def ensurelist(list):
    while len(lines) < OUTPUT_LINE_COUNT:
        lines.append("x")
        
def chunkstring(string, length):
    return (string[0+i:length+i] for i in range(0, len(string), length))
    
def printlist(lines):
    counter = 0
    for i in range(OUTPUT_LINE_COUNT):
        if counter == OUTPUT_LINE_COUNT:
            break

        if lines[i] == "x":
            print("{}.".format(i+1))
            counter +=1
        else:
            chunked = chunkstring(lines[i],MAX_LINE_LENGTH)
            for c in chunked:
                print("{}. {}".format(i+1,c.strip()))
                counter +=1


lines = getlines()
removeblanks(lines)        
ensurelist(lines)
printlist(lines)
