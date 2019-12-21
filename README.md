# LinxMon

LinxMon Instalation

install mono framework
Sudo apt-get install mono-complete

Copy LinxMon.exe and Newsoft.json.dll to /home/pi

Install crontab that every 10 min LinxMon.exe will be started
crontab -e
Add to file below
<Ip:port>-Node IP address and dashboard port usualy 14002
<NodeName>- one work without space
<Discord User ID> your user ID in Discord Chat
  
*/10 * * * * /usr/bin/mono /home/pi/LinxMon.exe <ip:port> <NodeName> <Discord User ID> 2> /home/pi/LinxMon.txt

Command to save crontab
Control-O
Enter
Control-X 
