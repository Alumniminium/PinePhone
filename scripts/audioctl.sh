#!/bin/bash

input=$1
volume=$2
earpiecevol=$(($volume * 2))

if [ $input = "s" ]; then
	amixer sset "Line Out Source" 'Mono Differential'
	amixer sset "Line Out" unmute
	amixer sset "Earpiece Source" 'Left Mix'
	amixer sset "Earpiece" unmute
	amixer sset "Earpiece" $earpiecevol%
	amixer sset "Line Out" $volume%
	amixer sset "DAC Reversed" unmute
elif [ $input = "h" ]; then
	amixer sset "Earpiece" mute
	amixer sset "Line Out" mute
	amixer sset "Headphone" unmute
	amixer sset "AIF1 Slot 0 Digital DAC" unmute
	amixer sset "AIF1 DA0 Stereo" "Stereo"
	amixer sset "AIF1 DA0" 15
	amixer sset "DAC" 100%
	amixer sset "Headphone" $volume%
else
	amixer sset "Line Out" mute
	amixer sset "DAC" unmute
	amixer sset "DAC Reversed" unmute
	amixer sset "Earpiece" unmute
	amixer sset "Earpiece" $volume%
fi
	
