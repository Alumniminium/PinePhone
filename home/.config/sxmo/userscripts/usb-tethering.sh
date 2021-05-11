#!/usr/bin/env sh

sudo sysctl net.ipv4.conf.usb0.forwarding=1

sudo iptables -t nat -A POSTROUTING -o wwan0 -j MASQUERADE
sudo iptables -A FORWARD -m conntrack --ctstate RELATED,ESTABLISHED -j ACCEPT
sudo iptables -A FORWARD -i usb0 -o wwan0 -j ACCEPT
