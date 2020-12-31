#!/usr/bin/env zsh

cp -rsf $PWD/.config/* "/home/$(whoami)/.config/"
mkdir "/home/$(whoami)/coding/" > /dev/null
cp -rsf $PWD/home/* "/home/$(whoami)/coding/"
mkdir "/home/$(whoami)/.local" > /dev/null
mkdir "/home/$(whoami)/.local/bin" > /dev/null
cp -rsf $PWD/scripts/* "/home/$(whoami)/.local/bin/"