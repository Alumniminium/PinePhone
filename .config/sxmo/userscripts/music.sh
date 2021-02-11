#!/usr/bin/env sh

/home/mo/.local/bin/audioctl.sh h 60
lxterminal -e sh -c 'mpv --shuffle /home/mo/music/'
