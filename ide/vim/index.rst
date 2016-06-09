======
VIM
======

中文乱码
========
使用以下命令，编辑VIM的配置文件。
::

 vi /etc/vim/vimrc

然后，按住 Shift 键和 g 跳到文件的末尾，按 i 键进入插入模式，然后粘贴以下代码到末尾
::

 set fileencodings=utf-8,gb2312,gbk,gb18030
 set termencoding=utf-8
 set encoding=prc
 
