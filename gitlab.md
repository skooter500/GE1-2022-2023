# Lab
### Learning Outcomes
- Learn how to use the main features of git via the git bash shell

This lab is all about practicing using git and github. This will work best if you for a group of 2, so that you can get experience collaborating with someone on a project through git. Firstly, make sure you know what the following bash commands do. Fire up the bash shell and try them out. There are lots more, but these are the most common ones I use. Google them and try them out!

```
pwd
ls
ls -a
cd
mkdir
mv
find
grep
```

Note, folders in the bash shell are separated using / and in Windows explorer you should have the following options checked:

- Show file name extensions
- Hidden files

You will find these options on the View tab of any Windows Explorer window

Also from the bash shell, you can use TAB to complete commands.

Setting up git
- I recommend you install [git for Windows](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git) rather than the github client. You can optionally install [SourceTree](https://www.sourcetreeapp.com/) which is a nice git gui program that allows you to *diff* commits (view the changes) amongst lots of other cool stuff.
- The first time you try and do a commit or a push you may have to run come commands to set up your email address and username. Just follow the instructions to do this.
- At some stage you should read the [first 3 chapters of the git manual](https://git-scm.com/documentation). This is pretty much all you need to know.

Note! Select the text using your mouse in the bash shell window and it will get copied to the clipboard. Press Ctrl + Ins to paste.

Basic stuff
- Create a Java file in Visual Studio Code and save it somewhere
- Fire up the bash shell and use cd to navigate to the project folder
- Type ```git init``` in the project folder to create an empty git repo. Notice that a new hidden folder called .git will appear in the folder
- Create the project on your github account on github.com. Dont forget to create a .gitignore and a readme.
- Get the url of the new repo and type:
  - ```git remote add origin THE_URL_OF_YOUR_REPO```
- Type ```git pull origin master``` to get the changes from the server. Type ```la -a``` and you should see the new files listed.
- Type ```git add .``` to add your local changes to the staging area
- Type ```git commit -m "some message"``` to make a commit
- Type ```git push --set-upstream origin master``` This creates the connection between your master branch and the master branch on the server
- Type ```git push``` to send your changes to the server

Rolling back to a previous commit
- Make a few more commits and push them
- Type ```git log``` to see the history of your branch and see the 40 digit hexedecimal id's of your commits. It should look something like this

  ```
  commit 7ccd905733dc710ecf38b0431d1143528b5dc1c7
  Author: skooter500 <skooter500@gmail.com>
  Date:   Thu Apr 14 10:03:17 2016 +0100

      Added todays lab

  commit 4b46bea9d2ccd434076310049a5553ccc241adc6
  Author: Bryan Duggan <skooter500@gmail.com>
  Date:   Fri Mar 25 12:55:44 2016 +0000

      classes and bullets example

  commit 6e949c599f038209c9b22da99d5b014a7c47387a
  Author: Bryan Duggan <skooter500@gmail.com>
  Date:   Thu Mar 3 09:15:18 2016 +0000

      broken link

  ```


- Copy one of the 40 digit ids and type ```git checkout THE-40-DIGIT-ID``` Open up your sketch and you should see it has reverted to the old version.
- Type ```git checkout master``` and the head pointer will move to the head of the branch (the latest commit). Open up your sketch and you should see it has changed to the latest version

Rolling back to a previous commit and making a new branch
- If you want to go back to an old version of a project and make changes, you will often see articles on stack overflow etc saying that you should hard reset the head. I recommend that you don't do this as this will delete the subsequent commits on the branch and you might want to get these changes back sometime. Instead, the best thing to do is make the changes on a new branch.
- Checkout one of the old commits again. Make some changes to the sketch
- Type ```git checkout -b my_new_branch``` You can call the branch something different if you want! The -b flag means create the new branch.
- Add and commit your changes to the new branch
- Now switch back to the master branch by typing ```git checkout master```. Open your sketch and verify that you are at the latest version of the project on the master branch.
- You can switch branches at anytime by typing ```git checkout THE_BRANCH_NAME```
- If you want to send this new branch to the server, checkout the branch (no -b flag this time) and type:
  - ```git push --set-upstream origin my_new_branch```
  - ```git push```

Deleting files
- git will normally just store files that have been added or modified in a commit. Files that are deleted don't get deleted in the commit so that if you checkout that commit, the files that you deleted will reappear. If you have deleted files in a commit you should use ```git add . --all```. Try it!

Branching
- You can create multiple branches in git if you want to try new stuff without screwing up your project. In fact it is common to create a new branch every time you want to add a new feature and then merge the branch into the master branch when the feature is completed. Lets try this.
- Type ```git checkout master``` to switch to the head of the master branch
- Type ```git branch``` This shows you what branch you are currently on. You can also type ```git branch --all`` to show all the branches.
- Type ```git checkout -b test_branch``` to create a new branch and switch to it
- Make some changes to to your Visual Studio Code file and save them
- Add and commit these changes.
- To send this new branch to the server type:
  - ```git push --set-upstream origin test_branch```
  - ```git push```
- Type ```git checkout master``` to switch to the master branch and check your java file to make sure your changes are gone.
- Type ```git checkout test_branch``` and open the Java file to make sure your changes are back again
- Type ```git checkout master``` to switch to the master branch again
- Now lets merge the test_branch changes into the master branch. Type ```git merge test_branch``` to do this
- Open your sketch and see that the changes you made on the test_branch have been merged in.
- Add and commit your merged changes.


Dealing with merge conficts
- Often, git will merge edits in files automatically, but merge conflicts can occur whenever commits have edits on the same line of the same file. This can happen even when only one person is working on a project. When this happens, git will tell you what files are causing problems and mark up the files with the changes from both commits.
- Give your team mate permission to commit to the repository. To do this, go to Settings | Collaborators and add their github id. Your team mate can clone the repository by typing:
  - ```git clone THE_URL_OF_THE_REPO```
- Now both of you should make some edits to the same file. Make some edits on the same lines of the file and on different lines of the file
- Your team mate should add, commit an push their changes. You can jump onto the github website and verify that their changes have been pushed
- Now you should add commit and try and push your changes. You will get a message that looks like this:

  ```
  To https://github.com/skooter500/TestGit
   ! [rejected]        master -> master (non-fast-forward)
  error: failed to push some refs to 'https://github.com/skooter500/TestGit'
  hint: Updates were rejected because the tip of your current branch is behind
  hint: its remote counterpart. Integrate the remote changes (e.g.
  hint: 'git pull ...') before pushing again.
  hint: See the 'Note about fast-forwards' in 'git push --help' for details.
  ```
- What this is saying is that there are changes on the server that you dont have and you need to pull and merge them before you can send your commit. To do this type:
- ```git pull```
- Now the changes from the head of the master branch on the server will get merged into your local git repository. git will attempt to merge files, but in this case you should get a merge conflict. It looks like this:

  ```
  Auto-merging TestGit/TestGit.Java
  CONFLICT (content): Merge conflict in TestGit/TestGit.Java
  Automatic merge failed; fix conflicts and then commit the result.
  ```
- If you open the file in question, you will see that it has been edited to look something like this:

  ```
  <<<<<<< HEAD
  // Hello from Bryan!
  =======
  // Hello from Tara!
  >>>>>>> c365e047b35d76bf3b2d48f38980db4b68746825

  void setup()
  {
  }
  ```
- The bits between <<<<<<< HEAD and ======= are the changes from your commit and the changes between ======= and >>>>>>> c365e047b35d76bf3b2d48f38980db4b68746825 are the changes from your team mates commit. Decide which bit you want to keep and delete the unwanted bits from the file and then add, commit and push your changes. Visual Studio Code knows about these annotations and will give you options to:

- Accept incoming change
- Accept upstream change
- Accept both

Merge conflicts on binary files
- Git can merge text files, with source code, but it cant merge binary files such as images. Lets see how to handle this
- Add an image to your project and have your team mate, commit and push this change.
- Have your team mate pull the repo to get the image.
- Now you should both have the image. Both of you should edit the image and save the changes
- Both you and your team mate should add and commit this change, but have your team mate push first
- When you try to push, you will get a message saying that your push has been rejected and you need to do a pull first

  ```
  To https://github.com/skooter500/TestGit
   ! [rejected]        master -> master (fetch first)
  error: failed to push some refs to 'https://github.com/skooter500/TestGit'
  hint: Updates were rejected because the remote contains work that you do
  hint: not have locally. This is usually caused by another repository pushing
  hint: to the same ref. You may want to first integrate the remote changes
  hint: (e.g., 'git pull ...') before pushing again.
  hint: See the 'Note about fast-forwards' in 'git push --help' for details.
  ```

- When you do a pull, you will get a merge conflict on the image file:

  ```
  From https://github.com/skooter500/TestGit
     c365e04..43b59e5  master     -> origin/master
  warning: Cannot merge binary files: TestGit/test.JPG (HEAD vs. 43b59e5d2c53c909fb227a02b6e65681fa91e42a)
  Auto-merging TestGit/test.JPG
  CONFLICT (content): Merge conflict in TestGit/test.JPG
  Automatic merge failed; fix conflicts and then commit the result.

  ```
- git doesn't know how to deal with these edits and so to resolve this conflict, you have to decide which version of the file you want to keep, the one from the server, or your version. If you want to keep your version, you type:
  - ```git checkout --ours THE_FILE_NAME```
  - Don't forget to use / to seperate paths and use TAB to complete commands
  - If you want to keep the version from the server you can type
  - ```git checkout --theirs THE_FILE_NAME```
  - You can type these commands multiple times if you want to just swicth between the two versions to compare them.
- When you are done, add, commit and push your changes

Congratulations! Don't forget to read [the first three chapters](https://git-scm.com/docs/user-manual) of the git manual.
