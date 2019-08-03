package mypack;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.orm.hibernate4.HibernateTemplate;
import org.springframework.stereotype.Component;
import org.springframework.transaction.annotation.Transactional;

@Component
@Transactional
public class UserDAOImpl implements UserDAO {

	@Autowired
	HibernateTemplate hibernateTemplate;
	
	@Override
	public boolean addUser(User u) {
		try
		{
			hibernateTemplate.save(u);
		}
		catch (Exception e) {
			return false;
		}
		return true;
	}

	@Override
	public List<User> getAllUsers() {
		List<User> users = (List<User>) hibernateTemplate.find("from User");
		return users;
	}
	
	

}
