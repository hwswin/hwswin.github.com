=======
SPHINX
=======

.. contents::
   :local:

Sphinx 使用手册
=====================================================================================

`Sphinx 使用手册 <https://zh-sphinx-doc.readthedocs.io/en/latest/contents.html>`_

安装
====

* 在Windows上安装Sphinx

	如果你的Windows电脑已经安装好了Python或Pip的话，步骤非常的简单，只需要在CMD窗口中执行 ``pip install Sphinx`` ，然后等待执行完毕就OK。

构建
====


reStructuredText 语法简介
==========================

内联标记
-----------

	* 星号: *text* 是强调 (斜体),
	* 双星号: **text** 重点强调 (加粗),
	* 反引号: ``text`` 代码样式.

列表
---------------

	开头放置一个星号和一个缩进. 编号的列表也可以使用符号 # 自动加序号:

	 * 这是一个项目符号列表.
	 * 它有两项，
	   第二项使用两行.

		 1. 这是个有序列表.
		 2. 也有两项.

		 #. 是个有序列表.
		 #. 也有两项.

表格
-------------

*简单表格*

	=====  =====  =======
	A      B      A and B
	=====  =====  =======
	False  False  False
	True   False  False
	False  True   False
	True   True   True
	=====  =====  =======

*网格表格*

	+------------------------+------------+----------+----------+
	| Header row, column 1   | Header 2   | Header 3 | Header 4 |
	| (header rows optional) |            |          |          |
	+========================+============+==========+==========+
	| body row 1, column 1   | column 2   | column 3 | column 4 |
	+------------------------+------------+----------+----------+
	| body row 2             | ...        | ...      |          |
	+------------------------+------------+----------+----------+

超链接
----------

*外部链接*

使用 `a <http://example.com/>`_ 可以插入网页链接. 
``链接文本是网址，则不需要特别标记，分析器会自动发现文本里的链接或邮件地址.``

	段落里包含 `a`_.



.. _a: http://example.com/

章节
-------

章节的标题在双上划线符号之间（或为下划线）

	* # 及上划线表示部分
	* \* 及上划线表示章节
	* =, 小章节
	* -, 子章节
	* ^, 子章节的子章节
	* ", 段落



上传到GitHub
=========================

master分支
-------------
::

	# edit .gitignore to ignore _build
	echo "_build" >> .gitignore
	git add .gitignore
	git commit -m 'ignoring _build'

	# create a new directory (in doc/)
	mkdir -p _build/html

	# clone the entire repo into this directory (yes, this duplicates it)
	git clone git@github.com:username/project.git _build/html

gh-pages分支
-------------
::

	# set this directory to track gh-pages
	git symbolic-ref HEAD refs/heads/gh-pages
	rm .git/index
	git clean -fdx

首次gh-pages分支提交
-----------------------
::

	# in docs/, run `make html` to generate our doc, which will fill 
	# _build/html, but not overwrite the .git directory
	cd ../..
	make html

	# now, add these bad-boys to the gh-pages repo, along with .nojekyll:
	cd _build/html
	touch .nojekyll
	git add .
	git commit -m 'first docs to gh-pages'
	git push origin gh-pages

	# [optional] cleanup stuff in duplicate master (in docs/_build/html)
	git checkout master
	rm .git/index
	git clean -fdx

日常文档修改提交
-----------------
::

	# now, when you run `make html` and need to update your documentation, 
	# you can do it "normally" without worrying about the many vagaries of 
	# submodule syncing (I can never get the order correct).  just make 
	# changes, then:
	make html
	cd _build/html
	git commit -a -m 'made some changes, yo'
	git push origin gh-pages
