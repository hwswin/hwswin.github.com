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
|        80      |      80（nginx）    |
+----------------+---------------------+
|        10003   |     8069 (odoo)     |
+----------------+---------------------+        


设置共享文件夹
---------------------

设置共享文件夹share为 ``固定分配``

挂载
------
::

    sudo mkdir /share
    sudo mount -t vboxsf share /share

SPHINX
======

构建

.. code-block:: docker

    docker run --name sphinx -v /share:/share -p 8000:8000 -it ubuntu bash

.. code-block:: shell
   :emphasize-lines: 2,7

    #阿里源加速
    sed -i 's|archive.ubuntu.com|mirrors.aliyun.com|g'  /etc/apt/sources.list \
    apt-get clean 
    apt-get update  

    apt-get install python-pip
    pip install --upgrade pip
    pip install sphinx sphinx_autobuild sphinx_rtd_theme

:ref:`sphinx-autobuild`

:ref:`sphinx-rtd-theme`

NGINX
======
::

    docker pull nginx
    docker run --name nginx -p 80:80 -d -v /share/nginx/conf.d/default.conf:/etc/nginx/conf.d/default.conf:ro  nginx


POSTGRES
==========
::

    docker pull postgres
    docker run -d -p 5432:5432 -e POSTGRES_USER=odoo -e POSTGRES_PASSWORD=odoo --name db postgres

POSTFIX
=========
::

    docker run -p 25:25 -e maildomain=mail.6erp.com -e smtp_user=admin:odoo --name postfix -d catatnight/postfix

ODOO
======
::

    docker pull odoo

    #docker run -p 8069:8069 --name odoo --link db:db -t odoo
    docker run -v /share/odoo/config:/etc/odoo -v /share/odoo/addons:/mnt/extra-addons -p 8069:8069 --name odoo --link db:db -t odoo

ODOO saas tools
=================
    
ubuntu
----------------------------------
::

    docker pull ubuntu:14.04
    docker run -v /share/odoo:/odoo  --name odooDev -it ubuntu:14.04

.. code-block:: shell

    #阿里源加速
    sed -i 's|archive.ubuntu.com|mirrors.aliyun.com|g'  /etc/apt/sources.list
    apt-get clean
    apt-get update

installed odoo
----------------------------------
.. code-block:: shell

    apt-get install git python-pip htop tree python-dev libpq-dev libxml2-dev libldap2-dev libsasl2-dev
    cd /odoo
    dpkg -i odoo_9.0.latest_all.deb #忽略错误
    apt-get -f install
    apt-get remove odoo

    # install wkhtmltox
    cd /usr/local/src
    lsb_release -a
    uname -i
    # check version of your OS and download appropriate package
    # http://wkhtmltopdf.org/downloads.html
    # e.g.
    apt-get install xfonts-base xfonts-75dpi
    apt-get -f install
    #wget http://download.gna.org/wkhtmltopdf/0.12/0.12.2.1/wkhtmltox-0.12.2.1_linux-trusty-amd64.deb
    cd /odoo
    dpkg -i wkhtmltox-*.deb

    # requirements.txt
    cd /odoo/odoo
    sudo pip install -r requirements.txt
    sudo pip install watchdog    

correctly configured odoo
----------------------------------
.. code-block:: shell

    #openerp-server.conf
    db-filter=^%h$ ? d
    workers=3    

    #restore openerp-gevent file
    cd /usr/bin/
    wget https://raw.githubusercontent.com/odoo/odoo/9.0/openerp-gevent
    chmod +x openerp-gevent

    
configured nginx
----------------------------------
.. code-block:: Nginx

    location /longpolling {
        proxy_pass http://127.0.0.1:8072;
    }
    location / {
        proxy_pass http://127.0.0.1:8069;
    }    
    
installed dependencies
----------------------------------
::

    1


其他
================

    #. 管理员身份运行::

        docker exec -u 0 -it odooSaaS bash

    #. 批量删除不完整的镜像::

        docker rmi -f $(docker images| awk '{if ($2=="<none>") print $3}')

    #. docker镜像加速::

        docker-machine ssh default
        sudo sed -i "s|EXTRA_ARGS='|EXTRA_ARGS='--registry-mirror=https://q9h4ikji.mirror.aliyuncs.com |g" /var/lib/boot2docker/profile
        exit
        docker-machine restart default

    #.设置npm镜像源 

        npm  config set registry http://registry.npm.taobao.org
        npm install -g cnpm --registry=https://registry.npm.taobao.org
