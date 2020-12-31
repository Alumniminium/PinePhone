#!/usr/bin/env zsh

cp -rs $PWD/.config/* "/home/$(whoami)/.config/"
mkdir "/home/$(whoami)/coding/"
cp -rs $PWD/home/* "/home/$(whoami)/home/coding/"
mkdir "/home/$(whoami)/.local"
mkdir "/home/$(whoami)/.local/bin"
cp -rs $PWD/scripts/* "/home/$(whoami)/.local/bin/"