package mypack;

import java.util.List;

import org.springframework.stereotype.Component;


public interface UserDAO {

	boolean addUser(User u);
	
	List<User> getAllUsers();
}
