#!/usr/bin/env zsh

cp -rsf $PWD/.config/* "/home/$(whoami)/.config/"
mkdir "/home/$(whoami)/coding/"
cp -rsf $PWD/home/* "/home/$(whoami)/home/coding/"
mkdir "/home/$(whoami)/.local"
mkdir "/home/$(whoami)/.local/bin"
cp -rsf $PWD/scripts/* "/home/$(whoami)/.local/bin/"