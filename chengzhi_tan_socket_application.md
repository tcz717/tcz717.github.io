# GSoC Student Application — LabLua

Applicant Name: Chengzhi Tan

## BASICS

1. What is your preferred e-mail address?

    tcz717@hotmail.com

2. What is your web page / blog / GitHub?

    GitHub Profile: <https://github.com/tcz717>

3. What is your academic background?

    * **Ohio State University**

        **Master of Engineering** in Electrical and Computer Engineering

        Expected in Jun.2019

    * **University of Electronic Science and Technology of China**

        **Bachelor of Science** in Electronic Information Science and Technology

        Jun.2017

4. What other time commitments, such as school work, another job (GSoC is a full-time activity!), or planned vacations will you have during the period of GSoC?

    None.

## EXPERIENCE

1. What programming languages are you fluent in? Which tools do you normally use for development?

    Languages: _C, C#, Python, Lua, TypeScript_

    Editors & IDEs: _Visual Studio, Visual Studio Code, Vim, PyCharm, Clion_

    Construction Tools: _Make, CMake, SCons_

    Version Control System: _Git_

2. Are you familiar with the Lua programming language? Have you developed any projects using Lua?

    Yes. I have participated in a Lua project named **System for Monitoring Pesticide Spraying Density**. Please see the detail in the following question.

3. Have you developed software in a team environment before? Any projects with actual users?

    Yes, some of my hobby projects and course team projects are developed in 2-3 members team in GitHub. But there is no project with actual users.

4. What kinds of projects/software have you worked on previously? (anything larger than a class project: academic research, internships, freelance, hobby projects, etc.)

    **System for Monitoring Pesticide Spraying Density**

    _Internship | Mar. - May. 2016 | AtrousTek Co. Ltd._

    ---------------------

    A system to collect data from the distributed outdoor sensors monitoring the spraying data and to send it to portable central device.

    * Using [NodeMCU](https://github.com/nodemcu/nodemcu-firmware), a Lua based firmware for ESP8266 WiFi SOC to read the sensor status and responding the other nodes' query request through UDP

    * Designed GUI with C#/GTK# on a Linux PC, displaying sensor status with continuous polling

    **Autonomous Drone with Aerial Photography Function**

    _Contest Project | Aug. 2015 | National Undergraduate Electronic Design Contest_

    ---------------------

    * Led a three-member team that developed the main program: the drivers, the AHRS (Attitude Heading Reference System), the flying attitude control algorithms, and line-tracking control algorithm with C language

    * Ported `RT-Thread` real-time operating system to manage the parallel tasks and the drivers

    * Participated in drone vision algorithm designing, resulting in 95-percent accurate rate

    * Open source in GitHub: <https://github.com/tcz717/TPDT.FC_407>

    **phishingPi**

    _Hobby Project | Mar. 2015_

    ---------------------

    A Python phishing tool to set a soft-AP on raspberryPi, filter any Http requests and DNS queries from the client and redirect the connection to a fake login website.

    * Created a filter program using `pcap` to capture packets from a wireless interface and `dpkt` to decode and reply packets.

    * Developed a phishing website using `Django` framework

    * Open source in GitHub: <https://github.com/tcz717/phishingPi>

    **teos**

    _Hobby Project | Work in Progress_

    ---------------------

    A learning purpose x86 operating system with POSIX compatible.

    * Implemented bootstrap, page management, interrupt management, GDB stub and memory management.

    * Future plan: VFS, module, process and program loader

    * Inspired by [osdev.org](https://wiki.osdev.org/Main_Page)

    * Open source in GitHub: <https://github.com/tcz717/teos>
    
    **SimCivil**

    _Hobby Project | Work in Progress_

    ---------------------

    A C# game server simulating a civilization world allowing roles free interacting. The key goals of the game are to dynamically generate any skills, technologies, recipes, and objects according to role behavior, and imitating real-world roles interacting logic as much as possible.

    * Implemented a `DotNetty` based RPC framework, an Entity-Component-System objects manager, and a state synchronizer

    * Future plan: porting to `Orleans`, a distributed virtual actor model framework and design dynamic generators for all game elements

    * The project includes unit tests, continuous integration (Travis CI), Docker and good document

    * Open source in GitHub: <https://github.com/tcz717/SimCivil>

    Other projects:

    * **Peer Pro Math App** — Academic Project

    * **External Device for Angry Birds Video Game** — Maker Competition Project

    * **Line Tracking Robot** — Contest Project

5. Are you (or have you been) involved with any open source development project? If so, briefly describe the project and the scope of your involvement.

    Yes, [RT-Thread](https://github.com/RT-Thread/rt-thread), an open source IoT operating system project from China.

    The scope of my involvement is mainly about document typo fix and bug submit.

## PROJECT

1. Did you select a project from our list? If yes, which project did you select? Why did you choose this project? If you are proposing a project, give a description of your proposal, including the expected results.

    Yes, `Develop Socket API for Lunatik`.

    I chose this project because I hope I can implement a way to reduce the barrier to kernel development. I have some Linux kernel and operating system learning experience and I found that without the necessary knowledge detail of kernel mechanism, it is hard to modify the behavior of an operating system.

    Due to the complex of Linux Kernel, developing Linux modules or changing kernel behavior become something difficult for people who are unfamiliar with the kernel. Obscure macros and pointers are found everywhere in kernel source files. These difficulties impede many developers involved kernel programming.

    Lua is a powerful, efficient, lightweight, embeddable scripting language, which brings another option for kernel developers. My goal is that by hiding annoying macros and complex API calling, developing a kernel socket program can become super easy and only needs few Lua codes. This goal coincides with the expected results of the project.

2. Please provide a schedule with dates and important milestones/deliverables, in two week increments.

    1. Week 1 – 2

        Implement Lua bindings for wrappers of kernel socket APIs.

        ```c
        EXPORT_SYMBOL(kernel_sendmsg);
        EXPORT_SYMBOL(kernel_recvmsg);
        EXPORT_SYMBOL(sock_create_kern);
        EXPORT_SYMBOL(sock_release);
        EXPORT_SYMBOL(kernel_bind);
        EXPORT_SYMBOL(kernel_listen);
        EXPORT_SYMBOL(kernel_accept);
        EXPORT_SYMBOL(kernel_connect);
        EXPORT_SYMBOL(kernel_getsockname);
        EXPORT_SYMBOL(kernel_getpeername);
        EXPORT_SYMBOL(kernel_getsockopt);
        EXPORT_SYMBOL(kernel_setsockopt);
        EXPORT_SYMBOL(kernel_sendpage);
        EXPORT_SYMBOL(kernel_sock_ioctl);
        EXPORT_SYMBOL(kernel_sock_shutdown);
        ```

        To do that, a wraper of `struct socket` and `sockaddr` is also requred (Some nest structures like `socket_wq`, `proto_ops` e.t.c are not included).

        That all are low-level API bindings.

    2. Week 3 - 4

        Implement a user-friend high-level encapsulation of socket. The possible APIs are

        ```lua
        net.createTCPClient()
        net.createTCPServer()
        net.createUDPSocket()
        net.multicastJoin(if_ip, multicast_ip)
        net.multicastLeave()

        net.server:close()
        net.server.listen([port],[ip],function(net.socket))
        net.server.getaddr()

        net.tcpsocket:close()
        net.tcpsocket:connect(port, ip|domain)
        net.tcpsocket:getpeer()
        net.tcpsocket:getaddr()
        net.tcpsocket:send(string[, function(sent)])
        net.tcpsocket:read()

        net.udpsocket:close()
        net.udpsocket:listen()
        net.udpsocket:read()
        net.udpsocket:send(string[, function(sent)])
        net.udpsocket:getaddr()
        ```

        Those APIs refer [NodeMCU's net module](https://github.com/nodemcu/nodemcu-firmware/blob/5073c199c01d4d7bbbcd0ae1f761ecc4687f7217/docs/en/modules/net.md)

    3. Week 5 - 6

        Implement more user-friend high-level encapsulations, especially `poll`. The possible APIs are

        ```lua
        net.server:poll(...)

        net.tcpsocket:ttl([ttl])
        net.tcpsocket:timeout([timeout])

        net.udpsocket:ttl([ttl])
        net.udpsocket:timeout([timeout])

        net.dns.getdnsserver(dns_index)
        net.dns.resolve(host, function(sk, ip))
        net.dns.setdnsserver(dns_ip_addr, dns_index)

        net.ping(addr[, ttl])
        ```

    4. Week 7 - 8

        Using kernel thread to implement event callback. For example,

        ```lua
        srv = net.createTCPServer()
        srv:on("receive", function(sck, c) print(c) end)
        -- Wait for connection before sending.
        srv:on("connection", function(sck, c)
        sck:send("GET /get HTTP/1.1\r\nHost: httpbin.org\r\nConnection: close\r\nAccept: */*\r\n\r\n")
        end)
        srv:connect(80,"httpbin.org")
        ```

        Inspired by [NodeMCU's net module](https://github.com/nodemcu/nodemcu-firmware/blob/5073c199c01d4d7bbbcd0ae1f761ecc4687f7217/docs/en/modules/net.md#netsocketon)

        And some other advanced socket options:

        ```lua
        net.tcpsocket:buffer([send_buffer, read_buffer])
        net.tcpsocket:dontLinger([on])
        net.tcpsocket:noDelay([on])
        ...
        ```
        
    5. Week 9 - 10

    Finishing all uncompleted features, doing tests, fixing bugs and doing benchmarks.

    6. week 11- 12

    Fixing bugs and completing documents.

3. What will be showable one month into the project?

    All APIs related to directly wrap Linux socket function and a demo to show how to use them.

4. What will be showable two months into the project?

    All APIs related to advanced socket encapsulations and a demo to show how to use them.

## GSOC

1. Have you participated as a student in GSoC before? If so, How many times, which year, which project?

    No, it's my first time.

2. Have you applied but were not selected? When?

    No.

3. Did you apply this year to any other organizations?

    No, it's the only organization I applied.
