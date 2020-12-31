#!/usr/bin/env zsh

cp -rsf $PWD/.config/* "/home/$(whoami)/.config/"
mkdir "/home/$(whoami)/coding/" 2>1& /dev/null
cp -rsf $PWD/home/* "/home/$(whoami)/coding/"
mkdir "/home/$(whoami)/.local" 2>1& /dev/null
mkdir "/home/$(whoami)/.local/bin" 2>1& /dev/null
cp -rsf $PWD/scripts/* "/home/$(whoami)/.local/bin/"