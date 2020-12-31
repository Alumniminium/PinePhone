#!/usr/bin/env sh

/home/mo/.local/bin/audioctl.sh h 60
st -e sh -c 'mocp -q ~/music/ -p --ascii -o shuffle'
