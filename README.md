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

# LinxRaport
LinxRaport Instalation

install mono framework, if you previosly instaled LinxMon no need to install mono any more
Sudo apt-get install mono-complete

Copy LinxMon.exe and Newsoft.json.dll to /home/pi

Install crontab that every last day of month 23:59 LinxRaport.exe will be started
You shoud corespond this time to UTC as dashboard reseted every month by UTC time.

crontab -e

Add to file below
<Ip:port>-Node IP address and dashboard port usualy 14002
<NodeName>- one work without space
<Discord User ID> your user ID in Discord Chat
  
  This needed to put write time, need to test
59 23 28-31 * * [[ "$(date --date=tomorrow +\%d)" == "01" ]] && /usr/bin/mono /home/pi/LinxRaport.exe <ip:port> <NodeName> <Discord User ID>

Command to save crontab

Control-O

Enter

Control-X 

