#!/usr/bin/env zsh

if [ "$(lpass status)" = 'Not logged in.' ]; then
    st -e sh -c 'lpass login domi@outlook.at'   
fi

ip=$(curl --no-progress-meter wtfismyip.com/text)
result=$(curl -X PUT "https://box.alumni.re/admin/dns/custom/pp.her.st" \
	-H "Content-Type: text/plain" \
	--data-raw "$ip" \
	-u "$(lpass show -u alumni.re):$(lpass show -p alumni.re)")

notify-send "dns update" "$result"

