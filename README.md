<<<<<<< Updated upstream
Points to consider while building for android native (Unity export)					
Gradle version	7.2					
Gradle Project version	7.1.2					
AndroidxVersion	1.9.0
=======
# UnityAsLibraryAndroid
UnityAsLibraryAndroid

public void Launch(String value)
    {
        try {
            Intent intent = new Intent(this,
                    Class.forName("com.shreenath.spaceappref.UnityHandlerActivity"));
            startActivity(intent);
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
>>>>>>> Stashed changes
