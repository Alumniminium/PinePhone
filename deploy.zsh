#!/usr/bin/env zsh

cp -rsf $PWD/.config/* "/home/$(whoami)/.config/"
mkdir "/home/$(whoami)/.local" > /dev/null 2>&1
mkdir "/home/$(whoami)/.local/bin" > /dev/null 2>&1
cp -rsf $PWD/scripts/* "/home/$(whoami)/.config/sxmo/userscripts/"
cp -rsf $PWD/scripts/* "/home/$(whoami)/.config/sxmo/userscripts/"
