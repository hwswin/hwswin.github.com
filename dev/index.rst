=================
开发语言
=================

.. toctree::
   :maxdepth: 2

PYTHON
========

简易HTTP服务器
-----------------

::

	python -m SimpleHTTPServer 8000

Git
========

Switching remote URLs from HTTPS to SSH
----------------------------------------

1. Open Git Bash.

#. Change the current working directory to your local project.

#. List your existing remotes in order to get the name of the remote you want to change.

	::

		git remote -v
		origin  https://github.com/USERNAME/REPOSITORY.git (fetch)
		origin  https://github.com/USERNAME/REPOSITORY.git (push)

#. Change your remote's URL from HTTPS to SSH with the git remote set-url command.

	::

		git remote set-url origin git@github.com:USERNAME/OTHERREPOSITORY.git

#. Verify that the remote URL has changed.

	::

		git remote -v

#. Verify new remote URL

	::

		origin  git@github.com:USERNAME/OTHERREPOSITORY.git (fetch)
		origin  git@github.com:USERNAME/OTHERREPOSITORY.git (push)