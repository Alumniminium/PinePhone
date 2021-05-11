#!/usr/bin/env sh

sudo sysctl net.ipv4.conf.wlan0.forwarding=1

sudo iptables -t nat -A POSTROUTING -o wwan0 -j MASQUERADE
sudo iptables -A FORWARD -m conntrack --ctstate RELATED,ESTABLISHED -j ACCEPT
sudo iptables -A FORWARD -i wlan0 -o wwan0 -j ACCEPT

sudo iptables -I INPUT -p udp --dport 67 -i net0 -j ACCEPT
sudo iptables -I INPUT -p udp --dport 53 -s 192.168.1.0/24 -j ACCEPT
sudo iptables -I INPUT -p tcp --dport 53 -s 192.168.1.0/24 -j ACCEPT

sudo ip link set down dev wlan0
sudo ip link set up dev wlan0
sudo ip addr add 192.168.1.1/24 dev wlan0

#sudo systemctl start hostapd
st -e sh -c 'sudo hostapd -i wlan0 /etc/hostapd/hostapd.conf' &
st -e sh -c 'watch arp | grep "192.168.1.*" | awk "{print $1}"' &