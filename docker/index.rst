=================
DOCKER
=================

.. contents::
   :local:

Virtual Box设置
================

端口转发
-----------------

	+----------------+---------------------+
	|    本机端口    |    子系统端口       |
	+================+=====================+
	|        80      |          80（nginx）|
	+----------------+---------------------+
	|        10003   |          8069 (odoo)|
	+----------------+---------------------+


设置共享文件夹
---------------------

	设置共享文件夹share为固定分配

挂载
--------------
	::

		sudo mkdir /share
		sudo mount -t vboxsf share /share

NGINX
==========
::

	docker pull nginx
	docker run --name nginx -p 80:80 -d -v /share/nginx/conf.d/default.conf:/etc/nginx/conf.d/default.conf:ro  nginx


POSTGRES
==========
::

	docker pull postgres
	docker run -d -p 5432:5432 -e POSTGRES_USER=odoo -e POSTGRES_PASSWORD=odoo --name db postgres

POSTFIX
========
::

	docker run -p 25:25 -e maildomain=mail.6erp.com -e smtp_user=admin:odoo --name postfix -d catatnight/postfix

ODOO
======
::

	docker pull odoo

	#docker run -p 8069:8069 --name odoo --link db:db -t odoo
	docker run -v /share/odoo/config:/etc/odoo -v /share/odoo/addons:/mnt/extra-addons -p 8069:8069 --name odoo --link db:db -t odoo


其他
================
::
	
	#管理员身份运行
	docker exec -u 0 -it odooSaaS bash

	#批量删除不完整的镜像
	docker rmi -f $(docker images| awk '{if ($2=="<none>") print $3}')